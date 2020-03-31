/*
 Navicat Premium Data Transfer

 Source Server         : my
 Source Server Type    : MySQL
 Source Server Version : 50067
 Source Host           : localhost:3306
 Source Schema         : attendance_sys

 Target Server Type    : MySQL
 Target Server Version : 50067
 File Encoding         : 65001

 Date: 28/03/2020 23:43:25
*/
use attendance_sys;

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;



-- ----------------------------
-- Table structure for t_attend
-- ----------------------------
DROP TABLE IF EXISTS `t_attend`;
CREATE TABLE `t_attend`  (
  `attend_id` bigint(20) NOT NULL,
  `rule_id` int(11) NULL DEFAULT NULL,
  `course_id` bigint(20) NULL DEFAULT NULL,
  `classroom_id` bigint(20) NULL DEFAULT NULL,
  `describes` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `attend_status` char(1) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`attend_id`),
  CONSTRAINT attend_course_id_fk FOREIGN KEY(course_id) REFERENCES t_course(course_id)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_attenditem
-- ----------------------------
DROP TABLE IF EXISTS `t_attenditem`;
CREATE TABLE `t_attenditem`  (
  `attendItem_id` bigint(20) NOT NULL,
  `attend_id` bigint(20) NULL DEFAULT NULL,
  `student_id` bigint(20) NULL DEFAULT NULL,
  `attend_time` datetime NULL DEFAULT NULL,
  `attend_reslut` char(1) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`attendItem_id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_attendrule
-- ----------------------------
DROP TABLE IF EXISTS `t_attendrule`;
CREATE TABLE `t_attendrule`  (
  `rule_id` int(11) NOT NULL,
  `rule_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `course_start_time` datetime NULL DEFAULT NULL,
  `course_end_time` datetime NULL DEFAULT NULL,
  `check_start_time` datetime NULL DEFAULT NULL,
  `check_end_time` datetime NULL DEFAULT NULL,
  `nomal_late_min` varchar(1) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `nomal_leave_early_min` varchar(1) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`rule_id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_camera
-- ----------------------------
DROP TABLE IF EXISTS `t_camera`;
CREATE TABLE `t_camera`  (
  `camera_id` int(11) NOT NULL,
  `camera_code` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `classroom_id` int(11) NULL DEFAULT NULL,
  `camera_ip` varchar(16) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `camera_port` int(11) NULL DEFAULT NULL,
  `camera_user` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `camera_pwd` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`camera_id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_classes
-- ----------------------------
DROP TABLE IF EXISTS `t_classes`;
CREATE TABLE `t_classes`  (
  `class_id` bigint(20) NOT NULL,
  `college_id` int(11) NULL DEFAULT NULL,
  `teacher_id` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `class_num` int(11) NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`class_id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_classroom
-- ----------------------------
DROP TABLE IF EXISTS `t_classroom`;
CREATE TABLE `t_classroom`  (
  `classroom_id` int(11) NOT NULL,
  `classroom_name` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `describes` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`classroom_id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_college
-- ----------------------------
DROP TABLE IF EXISTS `t_college`;
CREATE TABLE `t_college`  (
  `college_id` int(11) NOT NULL,
  `college_name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`college_id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_course
-- ----------------------------
DROP TABLE IF EXISTS `t_course`;
CREATE TABLE `t_course`  (
  `course_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `class_id` bigint(20) NULL DEFAULT NULL,
  `classroom_id` bigint(20) NULL DEFAULT NULL,
  `course_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `teacher_id` bigint(20) NULL DEFAULT NULL,
  `course_start_time` datetime NULL DEFAULT NULL,
  `course_start_week` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `course_end_time` datetime NULL DEFAULT NULL,
  `course_end_week` datetime NULL DEFAULT NULL,
  `school_year` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `semester` varchar(2) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `grade` varchar(2) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`course_id`)
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_dept
-- ----------------------------
DROP TABLE IF EXISTS `t_dept`;
CREATE TABLE `t_dept`  (
  `dept_id` int(11) NOT NULL AUTO_INCREMENT,
  `college_id` int(11) NULL DEFAULT NULL,
  `dept_name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `dept_describes` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`dept_id`)
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_faceinfo
-- ----------------------------
DROP TABLE IF EXISTS `t_faceinfo`;
CREATE TABLE `t_faceinfo`  (
  `id` bigint(20) NOT NULL,
  `studnet_id` bigint(20) NULL DEFAULT NULL,
  `face_id` varchar(31) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `group_id` bigint(20) NULL DEFAULT NULL,
  `face_feature` blob NULL,
  `image_path` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for t_student
-- ----------------------------
DROP TABLE IF EXISTS `t_student`;
CREATE TABLE `t_student`  (
  `student_id` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `class_id` bigint(20) NULL DEFAULT NULL,
  `student_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `student_gender` char(1) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `student_email` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `student_qq` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `user_id` bigint(20) NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`student_id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_student
-- ----------------------------
INSERT INTO `t_student` VALUES ('16201302', 162013t_classes, '徐甜', '0', '1204805820@qq.com', '1204805820', 1);
INSERT INTO `t_student` VALUES ('16201303', 162013, '张欣悦', '0', '246736367@qq.com', '246736367', 2);

-- ----------------------------
-- Table structure for t_teacher
-- ----------------------------
DROP TABLE IF EXISTS `t_teacher`;
CREATE TABLE `t_teacher`  (
  `teacher_id` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `dept_id` int(11) NULL DEFAULT NULL,
  `teacher_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `teacher_gender` char(1) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `teacher_email` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `teacher_qq` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `user_id` bigint(20) NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`teacher_id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_teacher
-- ----------------------------
INSERT INTO `t_teacher` VALUES ('laoduan11', 1, '老段哈', '1', '78787878@qq.com', '78787878', 3);
INSERT INTO `t_teacher` VALUES ('laoliu11', 3, '刘琳岚', '1', '1111111@qq.com', '111111', 4);

-- ----------------------------
-- Table structure for t_user
-- ----------------------------
DROP TABLE IF EXISTS `t_user`;
CREATE TABLE `t_user`  (
  `user_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `user_type` char(1) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `user_create_time` datetime NULL DEFAULT NULL,
  `last_login_time` datetime NULL DEFAULT NULL,
  `user_status` char(1) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY USING BTREE (`user_id`)
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of t_user
-- ----------------------------
INSERT INTO `t_user` VALUES (1, '16201302', '16201302', '2', '2020-03-28 18:12:18', '2020-03-28 18:12:34', '1');
INSERT INTO `t_user` VALUES (2, '16201303', '16201303', '2', '2020-03-28 18:13:35', '2020-03-28 18:13:40', '1');
INSERT INTO `t_user` VALUES (3, 'laoduan11', 'laoduan', '1', '2020-03-28 18:14:31', '2020-03-28 18:14:33', '1');
INSERT INTO `t_user` VALUES (4, 'laoliu11', 'laoliu11', '1', '2020-03-28 18:15:24', '2020-03-28 18:15:32', '1');

SET FOREIGN_KEY_CHECKS = 1;
