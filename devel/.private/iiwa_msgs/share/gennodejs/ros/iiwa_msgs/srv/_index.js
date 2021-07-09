
"use strict";

let SetSmartServoJointSpeedLimits = require('./SetSmartServoJointSpeedLimits.js')
let SetPTPJointSpeedLimits = require('./SetPTPJointSpeedLimits.js')
let SetEndpointFrame = require('./SetEndpointFrame.js')
let TimeToDestination = require('./TimeToDestination.js')
let ConfigureControlMode = require('./ConfigureControlMode.js')
let SetPTPCartesianSpeedLimits = require('./SetPTPCartesianSpeedLimits.js')
let SetWorkpiece = require('./SetWorkpiece.js')
let SetSpeedOverride = require('./SetSpeedOverride.js')
let SetSmartServoLinSpeedLimits = require('./SetSmartServoLinSpeedLimits.js')

module.exports = {
  SetSmartServoJointSpeedLimits: SetSmartServoJointSpeedLimits,
  SetPTPJointSpeedLimits: SetPTPJointSpeedLimits,
  SetEndpointFrame: SetEndpointFrame,
  TimeToDestination: TimeToDestination,
  ConfigureControlMode: ConfigureControlMode,
  SetPTPCartesianSpeedLimits: SetPTPCartesianSpeedLimits,
  SetWorkpiece: SetWorkpiece,
  SetSpeedOverride: SetSpeedOverride,
  SetSmartServoLinSpeedLimits: SetSmartServoLinSpeedLimits,
};
