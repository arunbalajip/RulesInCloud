/**
 * @license
 * Visual Blocks Editor
 *
 * Copyright 2012 Google Inc.
 * https://developers.google.com/blockly/
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

/**
 * @fileoverview Colour blocks for Blockly.
 * @author fraser@google.com (Neil Fraser)
 */
'use strict';

goog.provide('Blockly.Blocks.colour');

goog.require('Blockly.Blocks');


Blockly.Blocks['colour_picker'] = {
  /**
   * Block for colour picker.
   * @this Blockly.Block
   */
  init: function() {
    var OPERATORS =
      [['And', 'And'],
      ['AndAlso', 'AndAlso'],
      ['Or', 'Or'],
      ['OrElse', 'OrElse']];
    this.setHelpUrl(Blockly.Msg.COLOUR_PICKER_HELPURL);
    this.setColour(20);
    this.appendDummyInput()
        .appendField(new Blockly.FieldDropdown(OPERATORS), 'COLOUR');
    this.setOutput(true, 'RuleOperator');
    this.setTooltip(Blockly.Msg.COLOUR_PICKER_TOOLTIP);
  }
};

Blockly.Blocks['colour_random'] = {
  /**
   * Block for random colour.
   * @this Blockly.Block
   */
  init: function() {
    this.setHelpUrl(Blockly.Msg.COLOUR_RANDOM_HELPURL);
    this.setColour(20);
    this.appendDummyInput()
        .appendField(Blockly.Msg.COLOUR_RANDOM_TITLE);
    this.setOutput(true, 'Colour');
    this.setTooltip(Blockly.Msg.COLOUR_RANDOM_TOOLTIP);
  }
};

Blockly.Blocks['colour_rgb'] = {
  /**
   * Block for composing a colour from RGB components.
   * @this Blockly.Block
   */
  init: function() {
    this.setHelpUrl(Blockly.Msg.COLOUR_RGB_HELPURL);
    this.setColour(120);
    this.appendValueInput('WORKFLOWNAME')
        .setCheck('String')
        .setAlign(Blockly.ALIGN_RIGHT)
        .appendField('Workflow')
        .appendField('Workflow Name');

    this.appendStatementInput('RULES')
      .appendField("Rules");
    this.setTooltip(Blockly.Msg.COLOUR_RGB_TOOLTIP);
  }
};

Blockly.Blocks['colour_blend'] = {
  /**
   * Block for blending two colours together.
   * @this Blockly.Block
   */
  init: function() {
    this.setHelpUrl(Blockly.Msg.COLOUR_BLEND_HELPURL);
    this.setColour(20);

    this.appendValueInput('RULENAME')
        .setCheck('String')
        .setAlign(Blockly.ALIGN_RIGHT)
        .appendField('Rule')
        .appendField('Rule Name');
    this.appendValueInput('OPERATOR')
        .setCheck('RuleOperator')
        .setAlign(Blockly.ALIGN_RIGHT)
        .appendField('Operator');
    this.appendValueInput('SUCCESSEVENT')
        .setCheck('String')
        .setAlign(Blockly.ALIGN_RIGHT)
        .appendField('Success Event');
    this.appendValueInput('ERRORMESSAGE')
        .setCheck('String')
        .setAlign(Blockly.ALIGN_RIGHT)
        .appendField('Error Message')
    this.appendValueInput('EXPRESSION')
        .setCheck('Boolean')
        .setAlign(Blockly.ALIGN_RIGHT)
        .appendField('Expression')

    this.appendStatementInput('RULES')
      .appendField("Rules");

    this.setPreviousStatement(true);
    this.setNextStatement(true);
  }
};
