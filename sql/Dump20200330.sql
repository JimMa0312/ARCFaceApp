CREATE DATABASE  IF NOT EXISTS `attendance_sys` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `attendance_sys`;
-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: attendance_sys
-- ------------------------------------------------------
-- Server version	5.7.28-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `t_attend`
--

DROP TABLE IF EXISTS `t_attend`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_attend` (
  `attend_id` bigint(20) NOT NULL,
  `rule_id` int(11) DEFAULT NULL,
  `course_id` bigint(20) NOT NULL,
  `classroom_id` int(11) NOT NULL,
  `describes` varchar(255) DEFAULT NULL,
  `attend_status` char(1) DEFAULT NULL,
  PRIMARY KEY (`attend_id`) USING BTREE,
  KEY `attend_course_id_fk` (`course_id`),
  KEY `attend_classroom_id_fk` (`classroom_id`),
  KEY `attend_attendrule_id_fk` (`rule_id`),
  CONSTRAINT `attend_attendrule_id_fk` FOREIGN KEY (`rule_id`) REFERENCES `t_attendrule` (`rule_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `attend_classroom_id_fk` FOREIGN KEY (`classroom_id`) REFERENCES `t_classroom` (`classroom_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `attend_course_id_fk` FOREIGN KEY (`course_id`) REFERENCES `t_course` (`course_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_attend`
--

LOCK TABLES `t_attend` WRITE;
/*!40000 ALTER TABLE `t_attend` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_attend` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_attenditem`
--

DROP TABLE IF EXISTS `t_attenditem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_attenditem` (
  `attendItem_id` bigint(20) NOT NULL,
  `attend_id` bigint(20) NOT NULL,
  `student_id` varchar(20) NOT NULL,
  `attend_time` datetime DEFAULT NULL,
  `attend_reslut` char(1) DEFAULT NULL,
  PRIMARY KEY (`attendItem_id`) USING BTREE,
  KEY `attenditem_attend_id_fk` (`attend_id`),
  KEY `attenditem_student_id_fk` (`student_id`),
  CONSTRAINT `attenditem_attend_id_fk` FOREIGN KEY (`attend_id`) REFERENCES `t_attend` (`attend_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `attenditem_student_id_fk` FOREIGN KEY (`student_id`) REFERENCES `t_student` (`student_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_attenditem`
--

LOCK TABLES `t_attenditem` WRITE;
/*!40000 ALTER TABLE `t_attenditem` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_attenditem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_attendrule`
--

DROP TABLE IF EXISTS `t_attendrule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_attendrule` (
  `rule_id` int(11) NOT NULL,
  `rule_name` varchar(50) DEFAULT NULL,
  `course_start_time` datetime DEFAULT NULL,
  `course_end_time` datetime DEFAULT NULL,
  `check_start_time` datetime DEFAULT NULL,
  `check_end_time` datetime DEFAULT NULL,
  `nomal_late_min` varchar(1) DEFAULT NULL,
  `nomal_leave_early_min` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`rule_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_attendrule`
--

LOCK TABLES `t_attendrule` WRITE;
/*!40000 ALTER TABLE `t_attendrule` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_attendrule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_camera`
--

DROP TABLE IF EXISTS `t_camera`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_camera` (
  `camera_id` int(11) NOT NULL,
  `camera_code` varchar(50) DEFAULT NULL,
  `classroom_id` int(11) DEFAULT NULL,
  `camera_ip` varchar(16) DEFAULT NULL,
  `camera_port` int(11) DEFAULT NULL,
  `camera_user` varchar(200) DEFAULT NULL,
  `camera_pwd` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`camera_id`) USING BTREE,
  KEY `camera_classroom_id_fk` (`classroom_id`),
  CONSTRAINT `camera_classroom_id_fk` FOREIGN KEY (`classroom_id`) REFERENCES `t_classroom` (`classroom_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_camera`
--

LOCK TABLES `t_camera` WRITE;
/*!40000 ALTER TABLE `t_camera` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_camera` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_classes`
--

DROP TABLE IF EXISTS `t_classes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_classes` (
  `class_id` bigint(20) NOT NULL,
  `college_id` int(11) DEFAULT NULL,
  `teacher_id` varchar(10) DEFAULT NULL,
  `class_num` int(11) DEFAULT NULL,
  PRIMARY KEY (`class_id`) USING BTREE,
  KEY `class_teacher_id_fk` (`teacher_id`),
  KEY `class_college_id_fk` (`college_id`),
  CONSTRAINT `class_college_id_fk` FOREIGN KEY (`college_id`) REFERENCES `t_college` (`college_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `class_teacher_id_fk` FOREIGN KEY (`teacher_id`) REFERENCES `t_teacher` (`teacher_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_classes`
--

LOCK TABLES `t_classes` WRITE;
/*!40000 ALTER TABLE `t_classes` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_classes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_classroom`
--

DROP TABLE IF EXISTS `t_classroom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_classroom` (
  `classroom_id` int(11) NOT NULL,
  `classroom_name` varchar(10) DEFAULT NULL,
  `describes` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`classroom_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_classroom`
--

LOCK TABLES `t_classroom` WRITE;
/*!40000 ALTER TABLE `t_classroom` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_classroom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_college`
--

DROP TABLE IF EXISTS `t_college`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_college` (
  `college_id` int(11) NOT NULL,
  `college_name` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`college_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_college`
--

LOCK TABLES `t_college` WRITE;
/*!40000 ALTER TABLE `t_college` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_college` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_course`
--

DROP TABLE IF EXISTS `t_course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_course` (
  `course_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `class_id` bigint(20) DEFAULT NULL,
  `classroom_id` int(11) DEFAULT NULL,
  `course_name` varchar(255) DEFAULT NULL,
  `teacher_id` varchar(20) DEFAULT NULL,
  `course_start_time` datetime DEFAULT NULL,
  `course_start_week` varchar(10) DEFAULT NULL,
  `course_end_time` datetime DEFAULT NULL,
  `course_end_week` datetime DEFAULT NULL,
  `school_year` varchar(30) DEFAULT NULL,
  `semester` varchar(2) DEFAULT NULL,
  `grade` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`course_id`) USING BTREE,
  KEY `course_classes_id_fk` (`class_id`),
  KEY `course_classroom_id_fk` (`classroom_id`),
  KEY `course_teacher_id_fk` (`teacher_id`),
  CONSTRAINT `course_classes_id_fk` FOREIGN KEY (`class_id`) REFERENCES `t_classes` (`class_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `course_classroom_id_fk` FOREIGN KEY (`classroom_id`) REFERENCES `t_classroom` (`classroom_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `course_teacher_id_fk` FOREIGN KEY (`teacher_id`) REFERENCES `t_teacher` (`teacher_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_course`
--

LOCK TABLES `t_course` WRITE;
/*!40000 ALTER TABLE `t_course` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_dept`
--

DROP TABLE IF EXISTS `t_dept`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_dept` (
  `dept_id` int(11) NOT NULL AUTO_INCREMENT,
  `college_id` int(11) NOT NULL,
  `dept_name` varchar(20) DEFAULT NULL,
  `dept_describes` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`dept_id`) USING BTREE,
  KEY `dept_college_id_fk` (`college_id`),
  CONSTRAINT `dept_college_id_fk` FOREIGN KEY (`college_id`) REFERENCES `t_college` (`college_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_dept`
--

LOCK TABLES `t_dept` WRITE;
/*!40000 ALTER TABLE `t_dept` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_dept` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_faceinfo`
--

DROP TABLE IF EXISTS `t_faceinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_faceinfo` (
  `id` bigint(20) NOT NULL,
  `studnet_id` varchar(20) DEFAULT NULL,
  `face_id` varchar(31) DEFAULT NULL,
  `group_id` bigint(20) DEFAULT NULL,
  `face_feature` blob,
  `image_path` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `faceinfo_student_id_fk` (`studnet_id`),
  CONSTRAINT `faceinfo_student_id_fk` FOREIGN KEY (`studnet_id`) REFERENCES `t_student` (`student_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_faceinfo`
--

LOCK TABLES `t_faceinfo` WRITE;
/*!40000 ALTER TABLE `t_faceinfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_faceinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_student`
--

DROP TABLE IF EXISTS `t_student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_student` (
  `student_id` varchar(10) NOT NULL,
  `class_id` bigint(20) DEFAULT NULL,
  `student_name` varchar(255) DEFAULT NULL,
  `student_gender` char(1) DEFAULT NULL,
  `student_email` varchar(20) DEFAULT NULL,
  `student_qq` varchar(20) DEFAULT NULL,
  `user_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`student_id`) USING BTREE,
  KEY `student_user_id_fk` (`user_id`),
  KEY `student_class_id_fk` (`class_id`),
  CONSTRAINT `student_class_id_fk` FOREIGN KEY (`class_id`) REFERENCES `t_classes` (`class_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `student_user_id_fk` FOREIGN KEY (`user_id`) REFERENCES `t_user` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_student`
--

LOCK TABLES `t_student` WRITE;
/*!40000 ALTER TABLE `t_student` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_teacher`
--

DROP TABLE IF EXISTS `t_teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_teacher` (
  `teacher_id` varchar(20) NOT NULL DEFAULT '',
  `dept_id` int(11) DEFAULT NULL,
  `teacher_name` varchar(255) DEFAULT NULL,
  `teacher_gender` char(1) DEFAULT NULL,
  `teacher_email` varchar(20) DEFAULT NULL,
  `teacher_qq` varchar(20) DEFAULT NULL,
  `user_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`teacher_id`) USING BTREE,
  KEY `teacher_user_id_fk` (`user_id`),
  KEY `teacher_dept_id_fk` (`dept_id`),
  CONSTRAINT `teacher_dept_id_fk` FOREIGN KEY (`dept_id`) REFERENCES `t_dept` (`dept_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `teacher_user_id_fk` FOREIGN KEY (`user_id`) REFERENCES `t_user` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_teacher`
--

LOCK TABLES `t_teacher` WRITE;
/*!40000 ALTER TABLE `t_teacher` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_teacher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_user`
--

DROP TABLE IF EXISTS `t_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_user` (
  `user_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `user_type` char(1) DEFAULT NULL,
  `user_create_time` datetime DEFAULT NULL,
  `last_login_time` datetime DEFAULT NULL,
  `user_status` char(1) DEFAULT NULL,
  PRIMARY KEY (`user_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_user`
--

LOCK TABLES `t_user` WRITE;
/*!40000 ALTER TABLE `t_user` DISABLE KEYS */;
INSERT INTO `t_user` VALUES (1,'16201302','16201302','2','2020-03-28 18:12:18','2020-03-28 18:12:34','1'),(2,'16201303','16201303','2','2020-03-28 18:13:35','2020-03-28 18:13:40','1'),(3,'laoduan11','laoduan','1','2020-03-28 18:14:31','2020-03-28 18:14:33','1'),(4,'laoliu11','laoliu11','1','2020-03-28 18:15:24','2020-03-28 18:15:32','1');
/*!40000 ALTER TABLE `t_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'attendance_sys'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-30 21:35:46
