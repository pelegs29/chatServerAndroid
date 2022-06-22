-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.6.8-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping data for table chatappdb.contacts: ~16 rows (approximately)
DELETE FROM `contacts`;
/*!40000 ALTER TABLE `contacts` DISABLE KEYS */;
INSERT INTO `contacts` (`Id`, `contactOf`, `Name`, `Server`, `last`, `lastdate`, `UserId`) VALUES
	('edenc', 'itamarb', 'eden', 'localhost:5125', NULL, NULL, 'itamarb'),
	('edenc', 'matansha', 'eden cohen', 'localhost:5125', '1', '2022-06-22T16:40:11.9154799+03:00', 'matansha'),
	('edenc', 'nadavyk', 'eden', 'localhost:5125', 'heyo', '2022-06-22T21:23:16.2271886+03:00', 'nadavyk'),
	('edenc', 'pelegs29', 'eden', 'localhost:5125', 'ndandanda', '2022-06-22T21:39:27.8021563+03:00', 'pelegs29'),
	('itamarb', 'edenc', 'itamarb', 'localhost:5125', NULL, NULL, 'edenc'),
	('itamarb', 'nadavyk', 'itamar', 'localhost:5125', 'd', '2022-06-22T21:09:14.6042697+03:00', 'nadavyk'),
	('itamarb', 'pelegs29', 'Itamar', 'localhost:5125', 'cool!', '2022-01-23T09:23:12.904Z', 'pelegs29'),
	('matansha', 'edenc', 'matansha', 'localhost:5125', '1', '2022-06-22T16:40:11.8944168+03:00', 'edenc'),
	('matansha', 'nadavyk', 'matansha', 'localhost:5125', 'heyo', '2022-06-22T21:15:49.5371385+03:00', 'nadavyk'),
	('nadavyk', 'edenc', 'nadavyk', 'localhost:5125', 'heyo', '2022-06-22T21:23:16.2135646+03:00', 'edenc'),
	('nadavyk', 'itamarb', 'nadavyk', 'localhost:5125', 'd', '2022-06-22T21:09:14.6189712+03:00', 'itamarb'),
	('nadavyk', 'matansha', 'nadav', 'localhost:5125', 'heyo', '2022-06-22T21:15:49.5443473+03:00', 'matansha'),
	('nadavyk', 'pelegs29', 'Nadav', 'localhost:5125', 'check', '2022-06-22T20:56:51.1119313+03:00', 'pelegs29'),
	('pelegs29', 'edenc', 'pelegs29', 'localhost:5125', 'ndandanda', '2022-06-22T21:39:27.7874480+03:00', 'edenc'),
	('pelegs29', 'itamarb', 'Peleg Sh', 'localhost:5125', 'cool!', '2022-01-23T09:23:22.904Z', 'itamarb'),
	('pelegs29', 'nadavyk', 'Peleg Shlomo', 'localhost:5125', 'check', '2022-06-22T20:56:51.1265454+03:00', 'nadavyk');
/*!40000 ALTER TABLE `contacts` ENABLE KEYS */;

-- Dumping data for table chatappdb.contentapi: ~84 rows (approximately)
DELETE FROM `contentapi`;
/*!40000 ALTER TABLE `contentapi` DISABLE KEYS */;
INSERT INTO `contentapi` (`Id`, `Content`, `Created`, `Sent`, `ConversationId`) VALUES
	(1, 'HI', '2022-01-23T09:23:15.904Z', 1, 1),
	(8, 'HI', '2022-01-23T09:23:15.904Z', 0, 5),
	(24, 'dear friend', '2022-06-21T22:52:47.2422456+03:00', 1, 5),
	(25, 'dear friend', '2022-06-21T22:52:47.2382037+03:00', 0, 1),
	(26, 'r u here ?', '2022-06-21T22:53:14.3078632+03:00', 1, 5),
	(27, 'r u here ?', '2022-06-21T22:53:14.2959444+03:00', 0, 1),
	(28, 'yes im here', '2022-06-21T23:16:22.4340341+03:00', 1, 1),
	(29, 'yes im here', '2022-06-21T23:16:22.4393977+03:00', 0, 5),
	(56, 'a', '2022-06-22T16:00:42.5897842+03:00', 0, 15),
	(57, 'a', '2022-06-22T16:00:42.6440835+03:00', 1, 14),
	(58, 'b', '2022-06-22T16:08:52.7178637+03:00', 0, 14),
	(59, 'b', '2022-06-22T16:08:51.9365545+03:00', 1, 15),
	(60, 'gm', '2022-06-22T16:11:04.2145111+03:00', 1, 5),
	(61, 'gm', '2022-06-22T16:11:04.2142419+03:00', 0, 1),
	(62, 'c', '2022-06-22T16:21:30.4711767+03:00', 0, 15),
	(63, 'c', '2022-06-22T16:21:30.4952138+03:00', 1, 14),
	(64, 'd', '2022-06-22T16:21:49.0209770+03:00', 1, 15),
	(65, 'd', '2022-06-22T16:21:49.0206236+03:00', 0, 14),
	(66, 'e', '2022-06-22T16:31:14.6431116+03:00', 1, 15),
	(67, 'e', '2022-06-22T16:31:14.6741310+03:00', 0, 14),
	(68, 'f', '2022-06-22T16:31:32.8862157+03:00', 1, 14),
	(69, 'f', '2022-06-22T16:31:32.9501077+03:00', 0, 15),
	(70, '1', '2022-06-22T16:40:11.8944168+03:00', 1, 15),
	(71, '1', '2022-06-22T16:40:11.9154799+03:00', 0, 14),
	(72, 'test', '2022-06-22T19:30:19.5459609+03:00', 0, 11),
	(73, 'test', '2022-06-22T19:30:19.5538210+03:00', 1, 10),
	(74, 'kill hemi', '2022-06-22T19:30:33.2780182+03:00', 0, 10),
	(75, 'kill hemi', '2022-06-22T19:30:33.2786493+03:00', 1, 11),
	(76, 'a', '2022-06-22T19:35:34.0937305+03:00', 0, 11),
	(77, 'a', '2022-06-22T19:35:34.1051800+03:00', 1, 10),
	(78, 'good night', '2022-06-22T20:10:30.4848828+03:00', 0, 5),
	(79, 'good night', '2022-06-22T20:10:30.5035050+03:00', 1, 1),
	(80, 'hello', '2022-06-22T20:22:29.3710235+03:00', 1, 5),
	(81, 'hello', '2022-06-22T20:22:29.3697651+03:00', 0, 1),
	(82, 'hey !', '2022-06-22T20:22:44.3508032+03:00', 0, 5),
	(83, 'hey !', '2022-06-22T20:22:44.3610573+03:00', 1, 1),
	(84, '?', '2022-06-22T20:28:49.5648531+03:00', 1, 1),
	(85, '?', '2022-06-22T20:28:50.4438865+03:00', 0, 5),
	(86, '!', '2022-06-22T20:30:20.8316476+03:00', 1, 1),
	(87, '!', '2022-06-22T20:30:20.8134336+03:00', 0, 5),
	(88, '?', '2022-06-22T20:35:02.2969821+03:00', 0, 5),
	(89, '?', '2022-06-22T20:35:02.3192888+03:00', 1, 1),
	(90, '!', '2022-06-22T20:38:35.5301339+03:00', 0, 5),
	(91, '!', '2022-06-22T20:38:35.5390086+03:00', 1, 1),
	(92, '?', '2022-06-22T20:39:54.2437992+03:00', 0, 5),
	(93, '?', '2022-06-22T20:39:54.2639327+03:00', 1, 1),
	(94, '!', '2022-06-22T20:56:46.5530152+03:00', 1, 1),
	(95, '!', '2022-06-22T20:56:46.5687795+03:00', 0, 5),
	(96, 'check', '2022-06-22T20:56:51.1119313+03:00', 1, 1),
	(97, 'check', '2022-06-22T20:56:51.1265454+03:00', 0, 5),
	(98, 'b', '2022-06-22T21:02:12.5660209+03:00', 1, 11),
	(99, 'b', '2022-06-22T21:02:12.7693206+03:00', 0, 10),
	(100, 'c', '2022-06-22T21:09:08.6865065+03:00', 1, 10),
	(101, 'c', '2022-06-22T21:09:08.6758234+03:00', 0, 11),
	(102, 'd', '2022-06-22T21:09:14.6042697+03:00', 1, 11),
	(103, 'd', '2022-06-22T21:09:14.6189712+03:00', 0, 10),
	(104, 'hi', '2022-06-22T21:10:33.2252048+03:00', 1, 52),
	(105, 'hi', '2022-06-22T21:10:33.2391600+03:00', 0, 53),
	(106, 'hey', '2022-06-22T21:10:55.4849022+03:00', 1, 53),
	(107, 'hey', '2022-06-22T21:10:55.4923419+03:00', 0, 52),
	(108, 'heyo', '2022-06-22T21:11:05.1490617+03:00', 1, 52),
	(109, 'heyo', '2022-06-22T21:11:05.1623377+03:00', 0, 53),
	(110, 'heyo', '2022-06-22T21:15:49.5443473+03:00', 1, 55),
	(111, 'heyo', '2022-06-22T21:15:49.5371385+03:00', 0, 54),
	(112, 'test', '2022-06-22T21:20:56.7181782+03:00', 1, 57),
	(113, '?', '2022-06-22T21:22:01.7731457+03:00', 1, 57),
	(114, 'heyo', '2022-06-22T21:23:16.2135646+03:00', 1, 53),
	(115, 'heyo', '2022-06-22T21:23:16.2271886+03:00', 0, 52),
	(116, '2', '2022-06-22T21:23:32.8448062+03:00', 1, 56),
	(117, '2', '2022-06-22T21:23:32.8537490+03:00', 0, 57),
	(118, 'z', '2022-06-22T21:23:37.5760150+03:00', 1, 57),
	(119, '3', '2022-06-22T21:27:26.9389395+03:00', 1, 56),
	(120, '3', '2022-06-22T21:27:26.9508236+03:00', 0, 57),
	(121, '4', '2022-06-22T21:27:30.5211441+03:00', 1, 57),
	(122, '5', '2022-06-22T21:27:48.3220006+03:00', 1, 57),
	(123, '6', '2022-06-22T21:36:13.2957300+03:00', 1, 57),
	(124, '7', '2022-06-22T21:39:03.8682828+03:00', 1, 57),
	(125, '7', '2022-06-22T21:39:04.0765167+03:00', 0, 56),
	(126, 'aaa', '2022-06-22T21:39:14.4419430+03:00', 1, 56),
	(127, 'aaa', '2022-06-22T21:39:14.4406103+03:00', 0, 57),
	(128, 'rr', '2022-06-22T21:39:22.3845692+03:00', 1, 56),
	(129, 'rr', '2022-06-22T21:39:22.3839645+03:00', 0, 57),
	(130, 'ndandanda', '2022-06-22T21:39:27.7874480+03:00', 1, 57),
	(131, 'ndandanda', '2022-06-22T21:39:27.8021563+03:00', 0, 56);
/*!40000 ALTER TABLE `contentapi` ENABLE KEYS */;

-- Dumping data for table chatappdb.conversations: ~16 rows (approximately)
DELETE FROM `conversations`;
/*!40000 ALTER TABLE `conversations` DISABLE KEYS */;
INSERT INTO `conversations` (`Id`, `from`, `to`) VALUES
	(1, 'pelegs29', 'nadavyk'),
	(5, 'nadavyk', 'pelegs29'),
	(10, 'itamarb', 'nadavyk'),
	(11, 'nadavyk', 'itamarb'),
	(14, 'matansha', 'edenc'),
	(15, 'edenc', 'matansha'),
	(50, 'pelegs29', 'itamarb'),
	(51, 'itamarb', 'pelegs29'),
	(52, 'nadavyk', 'edenc'),
	(53, 'edenc', 'nadavyk'),
	(54, 'nadavyk', 'matansha'),
	(55, 'matansha', 'nadavyk'),
	(56, 'pelegs29', 'edenc'),
	(57, 'edenc', 'pelegs29'),
	(58, 'edenc', 'itamarb'),
	(59, 'itamarb', 'edenc');
/*!40000 ALTER TABLE `conversations` ENABLE KEYS */;

-- Dumping data for table chatappdb.users: ~5 rows (approximately)
DELETE FROM `users`;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`Id`, `Name`, `Password`) VALUES
	('edenc', 'eden cohen', '8888'),
	('itamarb', 'Itamar', '1111'),
	('matansha', 'matan shamir', '8888'),
	('nadavyk', 'Nadav', '1234'),
	('pelegs29', 'Peleg', '2910');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

-- Dumping data for table chatappdb.__efmigrationshistory: ~1 rows (approximately)
DELETE FROM `__efmigrationshistory`;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20220616123700_Initial', '6.0.6');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
