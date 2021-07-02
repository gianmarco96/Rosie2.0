
"use strict";

let SinePatternControlMode = require('./SinePatternControlMode.js');
let CartesianVelocity = require('./CartesianVelocity.js');
let CartesianPlane = require('./CartesianPlane.js');
let CartesianPose = require('./CartesianPose.js');
let ControlMode = require('./ControlMode.js');
let JointQuantity = require('./JointQuantity.js');
let JointPosition = require('./JointPosition.js');
let CartesianEulerPose = require('./CartesianEulerPose.js');
let DOF = require('./DOF.js');
let CartesianControlModeLimits = require('./CartesianControlModeLimits.js');
let JointTorque = require('./JointTorque.js');
let Spline = require('./Spline.js');
let CartesianQuantity = require('./CartesianQuantity.js');
let JointVelocity = require('./JointVelocity.js');
let JointDamping = require('./JointDamping.js');
let RedundancyInformation = require('./RedundancyInformation.js');
let JointStiffness = require('./JointStiffness.js');
let JointImpedanceControlMode = require('./JointImpedanceControlMode.js');
let JointPositionVelocity = require('./JointPositionVelocity.js');
let CartesianImpedanceControlMode = require('./CartesianImpedanceControlMode.js');
let DesiredForceControlMode = require('./DesiredForceControlMode.js');
let CartesianWrench = require('./CartesianWrench.js');
let SplineSegment = require('./SplineSegment.js');
let MoveAlongSplineActionFeedback = require('./MoveAlongSplineActionFeedback.js');
let MoveToCartesianPoseResult = require('./MoveToCartesianPoseResult.js');
let MoveToJointPositionAction = require('./MoveToJointPositionAction.js');
let MoveToCartesianPoseActionGoal = require('./MoveToCartesianPoseActionGoal.js');
let MoveToCartesianPoseActionFeedback = require('./MoveToCartesianPoseActionFeedback.js');
let MoveAlongSplineGoal = require('./MoveAlongSplineGoal.js');
let MoveToJointPositionFeedback = require('./MoveToJointPositionFeedback.js');
let MoveToJointPositionGoal = require('./MoveToJointPositionGoal.js');
let MoveAlongSplineAction = require('./MoveAlongSplineAction.js');
let MoveToCartesianPoseAction = require('./MoveToCartesianPoseAction.js');
let MoveToJointPositionActionFeedback = require('./MoveToJointPositionActionFeedback.js');
let MoveAlongSplineResult = require('./MoveAlongSplineResult.js');
let MoveToCartesianPoseActionResult = require('./MoveToCartesianPoseActionResult.js');
let MoveToJointPositionActionGoal = require('./MoveToJointPositionActionGoal.js');
let MoveToCartesianPoseGoal = require('./MoveToCartesianPoseGoal.js');
let MoveToJointPositionActionResult = require('./MoveToJointPositionActionResult.js');
let MoveAlongSplineActionResult = require('./MoveAlongSplineActionResult.js');
let MoveToJointPositionResult = require('./MoveToJointPositionResult.js');
let MoveAlongSplineFeedback = require('./MoveAlongSplineFeedback.js');
let MoveAlongSplineActionGoal = require('./MoveAlongSplineActionGoal.js');
let MoveToCartesianPoseFeedback = require('./MoveToCartesianPoseFeedback.js');

module.exports = {
  SinePatternControlMode: SinePatternControlMode,
  CartesianVelocity: CartesianVelocity,
  CartesianPlane: CartesianPlane,
  CartesianPose: CartesianPose,
  ControlMode: ControlMode,
  JointQuantity: JointQuantity,
  JointPosition: JointPosition,
  CartesianEulerPose: CartesianEulerPose,
  DOF: DOF,
  CartesianControlModeLimits: CartesianControlModeLimits,
  JointTorque: JointTorque,
  Spline: Spline,
  CartesianQuantity: CartesianQuantity,
  JointVelocity: JointVelocity,
  JointDamping: JointDamping,
  RedundancyInformation: RedundancyInformation,
  JointStiffness: JointStiffness,
  JointImpedanceControlMode: JointImpedanceControlMode,
  JointPositionVelocity: JointPositionVelocity,
  CartesianImpedanceControlMode: CartesianImpedanceControlMode,
  DesiredForceControlMode: DesiredForceControlMode,
  CartesianWrench: CartesianWrench,
  SplineSegment: SplineSegment,
  MoveAlongSplineActionFeedback: MoveAlongSplineActionFeedback,
  MoveToCartesianPoseResult: MoveToCartesianPoseResult,
  MoveToJointPositionAction: MoveToJointPositionAction,
  MoveToCartesianPoseActionGoal: MoveToCartesianPoseActionGoal,
  MoveToCartesianPoseActionFeedback: MoveToCartesianPoseActionFeedback,
  MoveAlongSplineGoal: MoveAlongSplineGoal,
  MoveToJointPositionFeedback: MoveToJointPositionFeedback,
  MoveToJointPositionGoal: MoveToJointPositionGoal,
  MoveAlongSplineAction: MoveAlongSplineAction,
  MoveToCartesianPoseAction: MoveToCartesianPoseAction,
  MoveToJointPositionActionFeedback: MoveToJointPositionActionFeedback,
  MoveAlongSplineResult: MoveAlongSplineResult,
  MoveToCartesianPoseActionResult: MoveToCartesianPoseActionResult,
  MoveToJointPositionActionGoal: MoveToJointPositionActionGoal,
  MoveToCartesianPoseGoal: MoveToCartesianPoseGoal,
  MoveToJointPositionActionResult: MoveToJointPositionActionResult,
  MoveAlongSplineActionResult: MoveAlongSplineActionResult,
  MoveToJointPositionResult: MoveToJointPositionResult,
  MoveAlongSplineFeedback: MoveAlongSplineFeedback,
  MoveAlongSplineActionGoal: MoveAlongSplineActionGoal,
  MoveToCartesianPoseFeedback: MoveToCartesianPoseFeedback,
};
