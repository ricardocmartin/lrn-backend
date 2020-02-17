DROP TABLE IF EXISTS `tb_course`;
CREATE TABLE `tb_course` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `KeyWords` varchar(255) DEFAULT NULL,
  `Thumbnail` varchar(255) DEFAULT NULL,
  `Idiom` varchar(100) DEFAULT NULL,
  `CreationDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `ModificationDate` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;

DROP TABLE IF EXISTS `tb_course_topic`;
CREATE TABLE `tb_course_topic` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CourseID` int(11) NOT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Resume` varchar(255) DEFAULT NULL,
  `KeyWords` varchar(255) DEFAULT NULL,
  `Thumbnail` varchar(255) DEFAULT NULL,
  `Idiom` varchar(100) DEFAULT NULL,
  `Sequence` int(11) NOT NULL,
  `CreationDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `ModificationDate` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `CourseID` (`CourseID`),
  CONSTRAINT `course_topic_ibfk_1` FOREIGN KEY (`CourseID`) REFERENCES `tb_course` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;

DROP TABLE IF EXISTS `tb_content`;
CREATE TABLE `tb_content` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `Url` varchar(255) DEFAULT NULL,
  `Thumbnail` varchar(255) DEFAULT NULL,
  `KeyWords` varchar(255) DEFAULT NULL,
  `CreationDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `ModificationDate` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Transcript` text,
  PRIMARY KEY (`ID`),
  KEY `CourseID` (`CourseID`),
  CONSTRAINT `content_ibfk_1` FOREIGN KEY (`CourseID`) REFERENCES `tb_course` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;


DROP TABLE IF EXISTS `tb_content_vote`;
CREATE TABLE `tb_content_vote` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ID`),
  `ContentID` int(11) NOT NULL,
  `CourseTopicID` int(11) NOT NULL,
  KEY `ContentID` (`ContentID`),
  KEY `CourseTopicID` (`CourseTopicID`),
  CONSTRAINT `content_topic_ibfk_1` FOREIGN KEY (`CourseTopicID`) REFERENCES `tb_content_topic` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;
