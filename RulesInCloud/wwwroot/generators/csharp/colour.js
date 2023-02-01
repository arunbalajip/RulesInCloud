'use strict';

Blockly.CSharp.colour = {};

Blockly.CSharp.colour_picker = function() {
  // Colour picker.
  var code = goog.string.quote(this.getTitleValue('COLOUR'));
  return [code, Blockly.CSharp.ORDER_ATOMIC];
};

Blockly.CSharp.colour_random = function() {
  // Generate a random colour.
  if (!Blockly.CSharp.definitions_['colour_random']) {
    var functionName = Blockly.CSharp.variableDB_.getDistinctName(
        'colour_random', Blockly.Generator.NAME_TYPE);
    Blockly.CSharp.colour_random.functionName = functionName;
    var func = [];
    func.push('var ' + functionName + ' = new Func<Color>(() => {');
    func.push('  var random = new Random();');
    func.push('  var res = Color.FromArgb(1, random.Next(256), random.Next(256), random.Next(256));');
    func.push('  return res;');
    func.push('});');
    Blockly.CSharp.definitions_['colour_random'] = func.join('\n');
  }
  var code = Blockly.CSharp.colour_random.functionName + '()';
  return [code, Blockly.CSharp.ORDER_FUNCTION_CALL];
};

Blockly.CSharp.colour_rgb = function() {
  // Compose a colour from RGB components expressed as percentages.
  var workflowName = Blockly.CSharp.valueToCode(this, 'WORKFLOWNAME', Blockly.CSharp.ORDER_NONE) || '""';

  var code = [];
  code.push('  "workflowName": ' + workflowName);

  var rules = Blockly.CSharp.statementToCode(this, 'RULES');

  if (rules != "") {
    code.push(rules);
  }

  return '{\n' + code.join(',\n') + '\n}';
};

Blockly.CSharp.colour_blend = function () {
  // Blend two colours together.
  var variables = {
    "RuleName": Blockly.CSharp.valueToCode(this, 'RULENAME', Blockly.CSharp.ORDER_NONE) || '""',
    "Operator": Blockly.CSharp.valueToCode(this, 'OPERATOR', Blockly.CSharp.ORDER_NONE) || '""',
    "SuccessEvent": Blockly.CSharp.valueToCode(this, 'SUCCESSEVENT', Blockly.CSharp.ORDER_NONE) || '""',
    "ErrorMessage": Blockly.CSharp.valueToCode(this, 'ERRORMESSAGE', Blockly.CSharp.ORDER_NONE) || '""',
    "Expression": Blockly.CSharp.valueToCode(this, 'EXPRESSION', Blockly.CSharp.ORDER_NONE) || '""',
  };

  if (variables["Expression"] != '""') (variables["Expression"] = Blockly.CSharp.format_expression(variables["Expression"]));

  var code = [];
  for (var key in variables) {

    if (variables[key] != '""')
      code.push('  "' + key + '": ' + variables[key]);
  }

  var rules = Blockly.CSharp.statementToCode(this, 'RULES');

  if (rules != "") {
    code.push(rules);
  }

  return '{\n' + code.join(',\n') + '\n}';
};

Blockly.CSharp.format_expression = function (expression) {
  var ans = '"';
  for (var ch in expression) {
    if (expression[ch] == '"') ans += '\\';
    ans += expression[ch];
  }
  ans += '"';

  return ans;
}
