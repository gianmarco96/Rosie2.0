
"use strict";

let SetEndpointFrame = require('./SetEndpointFrame.js')
let SetSmartServoLinSpeedLimits = require('./SetSmartServoLinSpeedLimits.js')
let SetSmartServoJointSpeedLimits = require('./SetSmartServoJointSpeedLimits.js')
let SetPTPCartesianSpeedLimits = require('./SetPTPCartesianSpeedLimits.js')
let SetSpeedOverride = require('./SetSpeedOverride.js')
let TimeToDestination = require('./TimeToDestination.js')
let ConfigureControlMode = require('./ConfigureControlMode.js')
let SetWorkpiece = require('./SetWorkpiece.js')
let SetPTPJointSpeedLimits = require('./SetPTPJointSpeedLimits.js')

module.exports = {
  SetEndpointFrame: SetEndpointFrame,
  SetSmartServoLinSpeedLimits: SetSmartServoLinSpeedLimits,
  SetSmartServoJointSpeedLimits: SetSmartServoJointSpeedLimits,
  SetPTPCartesianSpeedLimits: SetPTPCartesianSpeedLimits,
  SetSpeedOverride: SetSpeedOverride,
  TimeToDestination: TimeToDestination,
  ConfigureControlMode: ConfigureControlMode,
  SetWorkpiece: SetWorkpiece,
  SetPTPJointSpeedLimits: SetPTPJointSpeedLimits,
};
