var fs = require('fs'),
	rdr = require('line-reader'),
	util = require('util'),
	file = process.argv[2];

if(!file)
	throw "Provide spec file as first argument";

if(!fs.existsSync(file))
	throw "File '" + file + "' does not exist.";

function Type(name, ns, template) {
	this.name = name;
	this.namespace = ns;
	this.template = template;
	this.istemplate = false;
	this.properties = [];
}

Type.prototype = {
	addProperties: function(input) {
		if(!input) return;

		var self = this, 
		    fields = input.trim().split(' ');

		fields.forEach(function(field) {
			if(!field.trim()) return;

			var data = field.split(':');
			var property = data.length == 2 
				? new Property(data[0], data[1]) 
				: new Property('s', field);
			self.properties.push(property);
		});
	},

	dump: function() {
		return this.name + ': ' + this.properties[0].type + ', ' + this.properties[1].name;
	}
}

function Property(type, name) {
	this.name = name;
	this.type = type;
}

var types = [], lines = fs.readFileSync(file).toString().split("\n");

var patt = /^([a-z]+)(\s*:\s*([a-z]+))?(\s*\{([\sa-z0-9:]+)\})?$/i,
	nsp = /^NS:\s*([a-z]+)$/i,
	namespace = '';

lines.forEach(function(line) {
	line = line.replace(/[\r\n]+$/gi, '');
	if(line) {
		var nsparts = nsp.exec(line);
		if(nsparts) {
			namespace = nsparts[1];
		} else {
			var parts = patt.exec(line);
			if(parts) {
				var type = new Type(parts[1], namespace, parts[3]);
				if(parts[5]) {
					type.addProperties(parts[5]);
				}
				types.push(type);
			}
		}
	}
});

var lookup = {};
types.forEach(function(type) {
	lookup[type.name] = type;
});

types.forEach(function(type) {
	if(type.template) {
		var template = lookup[type.template];

		if(!template)
			throw "Can't find template '" + type.template + "'";

		template.istemplate = true;
		template.properties.concat().reverse().forEach(function(prop) {
			type.properties.unshift(prop);
		});
	}
});

function typeCode(s) {
	switch(s) {
		case 's': return 'string';
		case 'i': return 'int';
		case 'l': return 'long';
		case 'dt': return 'DateTime';
		default: throw "Can't convert type code '" + s + "' to something valid";
	}
}

var namespaces = {};
types.forEach(function(type) {
	var ns = type.namespace;
	namespaces[ns] = namespaces[ns] || [];
	namespaces[ns].push(type);
});

var output = '';
for(ns in namespaces) {
	var concreteTypes = namespaces[ns].filter(function(type) { return !type.istemplate; });
	if(!concreteTypes.length) continue;
	output += util.format("namespace Events.%s\n{\n", ns || "Common");
	concreteTypes.forEach(function(type) {
		output += util.format("\tpublic class %s : IEvent\n\t{\n", type.name);
		type.properties.forEach(function(prop) {
			output += util.format("\t\tpublic %s %s { get; set; }\n", typeCode(prop.type), prop.name);
		});
		output += "\t}\n\n";
	});
	output = output.trim();
	output += "\n}\n\n";
}

output = output.trim();

console.log(output);
