using System.Collections.Generic;
using ModernEncryption.Model;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class MathematicalMappingLogic
    {
        public static Dictionary<char, Interval> IntervalTable { get; set; } = new Dictionary<char, Interval>();
        public static Dictionary<int, char> TransformationTable { get; set; } = new Dictionary<int, char>();
        public static Dictionary<char, int> BackTransformationTable { get; set; } = new Dictionary<char, int>();
        public static Dictionary<int, int> KeyTable = new Dictionary<int, int>();

        public void InitalizeIntervalTable()
        {
            var A = new Interval(1, 8);

            var a = new Interval(9, 84);

            var B = new Interval(85, 86);

            var b = new Interval(87, 108);

            var C = new Interval(109, 111);

            var c = new Interval(112, 147);

            var D = new Interval(148, 153);

            var d = new Interval(154, 213);

            var E = new Interval(214, 235);

            var e = new Interval(236, 439);

            var F = new Interval(440, 441);

            var f = new Interval(442, 460);

            var G = new Interval(461, 463);

            var g = new Interval(464, 499);

            var H = new Interval(500, 504);

            var h = new Interval(506, 561);

            var I = new Interval(562, 570);

            var i = new Interval(571, 659);

            var J = new Interval(660, 660);

            var j = new Interval(661, 662);

            var K = new Interval(663, 663);

            var k = new Interval(664, 677);

            var L = new Interval(678, 681);

            var l = new Interval(682, 721);

            var M = new Interval(722, 724);

            var m = new Interval(725, 753);

            var N = new Interval(754, 765);

            var n = new Interval(766, 880);

            var O = new Interval(881, 882);

            var o = new Interval(882, 912);

            var P = new Interval(913, 913);

            var p = new Interval(914, 922);

            var Q = new Interval(505, 505);

            var q = new Interval(923, 923);

            var R = new Interval(924, 931);

            var r = new Interval(933, 1014);

            var S = new Interval(1015, 1023);

            var s = new Interval(1024, 1108);

            var T = new Interval(1109, 1115);

            var t = new Interval(1117, 1188);

            var U = new Interval(1189, 1193);

            var u = new Interval(1194, 1244);

            var V = new Interval(1245, 1245);

            var v = new Interval(1246, 1252);

            var W = new Interval(1253, 1254);

            var w = new Interval(1255, 1276);

            var X = new Interval(932, 932);

            var x = new Interval(1277, 1277);

            var Y = new Interval(1116, 1116);

            var y = new Interval(1278, 1278);

            var Z = new Interval(1279, 1279);

            var z = new Interval(1280, 1292);

            var sharpS = new Interval(1293, 1296);

            var dot = new Interval(1297, 1312);

            var comma = new Interval(1313, 1335);

            var space = new Interval(1336, 1590);

            var one = new Interval(1591, 1591);

            var two = new Interval(1592, 1592);

            var three = new Interval(1593, 1593);

            var four = new Interval(1594, 1594);

            var five = new Interval(1595, 1595);

            var six = new Interval(1596, 1596);

            var seven = new Interval(1597, 1597);

            var eight = new Interval(1598, 1598);

            var nine = new Interval(1599, 1599);

            var zero = new Interval(1600, 1600);

            IntervalTable.Add('a', a);
            IntervalTable.Add('b', b);
            IntervalTable.Add('c', c);
            IntervalTable.Add('d', d);
            IntervalTable.Add('e', e);
            IntervalTable.Add('f', f);
            IntervalTable.Add('g', g);
            IntervalTable.Add('h', h);
            IntervalTable.Add('i', i);
            IntervalTable.Add('j', j);
            IntervalTable.Add('k', k);
            IntervalTable.Add('l', l);
            IntervalTable.Add('m', m);
            IntervalTable.Add('n', n);
            IntervalTable.Add('o', o);
            IntervalTable.Add('p', p);
            IntervalTable.Add('q', q);
            IntervalTable.Add('r', r);
            IntervalTable.Add('s', s);
            IntervalTable.Add('t', t);
            IntervalTable.Add('u', u);
            IntervalTable.Add('v', v);
            IntervalTable.Add('w', w);
            IntervalTable.Add('x', x);
            IntervalTable.Add('y', y);
            IntervalTable.Add('z', z);
            IntervalTable.Add('A', A);
            IntervalTable.Add('B', B);
            IntervalTable.Add('C', C);
            IntervalTable.Add('D', D);
            IntervalTable.Add('E', E);
            IntervalTable.Add('F', F);
            IntervalTable.Add('G', G);
            IntervalTable.Add('H', H);
            IntervalTable.Add('I', I);
            IntervalTable.Add('J', J);
            IntervalTable.Add('K', K);
            IntervalTable.Add('L', L);
            IntervalTable.Add('M', M);
            IntervalTable.Add('N', N);
            IntervalTable.Add('O', O);
            IntervalTable.Add('P', P);
            IntervalTable.Add('Q', Q);
            IntervalTable.Add('R', R);
            IntervalTable.Add('S', S);
            IntervalTable.Add('T', T);
            IntervalTable.Add('U', U);
            IntervalTable.Add('V', V);
            IntervalTable.Add('W', W);
            IntervalTable.Add('X', X);
            IntervalTable.Add('Y', Y);
            IntervalTable.Add('Z', Z);
            IntervalTable.Add('ß', sharpS);
            IntervalTable.Add('.', dot);
            IntervalTable.Add(',', comma);
            IntervalTable.Add(' ', space);
            IntervalTable.Add('1', one);
            IntervalTable.Add('2', two);
            IntervalTable.Add('3', three);
            IntervalTable.Add('4', four);
            IntervalTable.Add('5', five);
            IntervalTable.Add('6', six);
            IntervalTable.Add('7', seven);
            IntervalTable.Add('8', eight);
            IntervalTable.Add('9', nine);
            IntervalTable.Add('0', zero);
        }

        public void InitalizeTransformationTable()
        {
            TransformationTable.Add(1, 'a');
            TransformationTable.Add(2, 'b');
            TransformationTable.Add(3, 'c');
            TransformationTable.Add(4, 'd');
            TransformationTable.Add(5, 'e');
            TransformationTable.Add(6, 'f');
            TransformationTable.Add(7, 'g');
            TransformationTable.Add(8, 'h');
            TransformationTable.Add(9, 'i');
            TransformationTable.Add(10, 'j');
            TransformationTable.Add(11, 'k');
            TransformationTable.Add(12, 'l');
            TransformationTable.Add(13, 'm');
            TransformationTable.Add(14, 'n');
            TransformationTable.Add(15, 'o');
            TransformationTable.Add(16, 'p');
            TransformationTable.Add(17, 'q');
            TransformationTable.Add(18, 'r');
            TransformationTable.Add(19, 's');
            TransformationTable.Add(20, 't');
            TransformationTable.Add(21, 'u');
            TransformationTable.Add(22, 'v');
            TransformationTable.Add(23, 'w');
            TransformationTable.Add(24, 'x');
            TransformationTable.Add(25, 'y');
            TransformationTable.Add(26, 'z');
            TransformationTable.Add(27, 'ß');
            TransformationTable.Add(28, '.');
            TransformationTable.Add(29, ',');
            TransformationTable.Add(30, ' ');
            TransformationTable.Add(31, '1');
            TransformationTable.Add(32, '2');
            TransformationTable.Add(33, '3');
            TransformationTable.Add(34, '4');
            TransformationTable.Add(35, '5');
            TransformationTable.Add(36, '6');
            TransformationTable.Add(37, '7');
            TransformationTable.Add(38, '8');
            TransformationTable.Add(39, '9');
            TransformationTable.Add(40, '0');
        }

        public void InitializeKeyTable()
        {

            KeyTable.Add(1, 1001);
            KeyTable.Add(2, 1002);
            KeyTable.Add(3, 1003);
            KeyTable.Add(4, 1004);
            KeyTable.Add(5, 1005);
            KeyTable.Add(6, 1006);
            KeyTable.Add(7, 1007);
            KeyTable.Add(8, 1008);
            KeyTable.Add(9, 1009);
            KeyTable.Add(10, 1010);
            KeyTable.Add(11, 1011);
            KeyTable.Add(12, 1012);
            KeyTable.Add(13, 1013);
            KeyTable.Add(14, 1014);
            KeyTable.Add(15, 1015);
            KeyTable.Add(16, 1016);
            KeyTable.Add(17, 1017);
            KeyTable.Add(18, 1018);
            KeyTable.Add(19, 1019);
            KeyTable.Add(20, 1020);
            KeyTable.Add(21, 1021);
            KeyTable.Add(22, 1022);
            KeyTable.Add(23, 1023);
            KeyTable.Add(24, 1024);
            KeyTable.Add(25, 1025);
            KeyTable.Add(26, 1026);
            KeyTable.Add(27, 1027);
            KeyTable.Add(28, 1028);
            KeyTable.Add(29, 1029);
            KeyTable.Add(30, 1030);
            KeyTable.Add(31, 1031);
            KeyTable.Add(32, 1032);
            KeyTable.Add(33, 1033);
            KeyTable.Add(34, 1034);
            KeyTable.Add(35, 1035);
            KeyTable.Add(36, 1036);
            KeyTable.Add(37, 1037);
            KeyTable.Add(38, 1038);
            KeyTable.Add(39, 1039);
            KeyTable.Add(40, 1040);
            KeyTable.Add(41, 1041);
            KeyTable.Add(42, 1042);
            KeyTable.Add(43, 1043);
            KeyTable.Add(44, 1044);
            KeyTable.Add(45, 1045);
            KeyTable.Add(46, 1046);
            KeyTable.Add(47, 1047);
            KeyTable.Add(48, 1048);
            KeyTable.Add(49, 1049);
            KeyTable.Add(50, 1050);
            KeyTable.Add(51, 1051);
            KeyTable.Add(52, 1052);
            KeyTable.Add(53, 1053);
            KeyTable.Add(54, 1054);
            KeyTable.Add(55, 1055);
            KeyTable.Add(56, 1056);
            KeyTable.Add(57, 1057);
            KeyTable.Add(58, 1058);
            KeyTable.Add(59, 1059);
            KeyTable.Add(60, 1060);
            KeyTable.Add(61, 1061);
            KeyTable.Add(62, 1062);
            KeyTable.Add(63, 1063);
            KeyTable.Add(64, 1064);
            KeyTable.Add(65, 1065);
            KeyTable.Add(66, 1066);
            KeyTable.Add(67, 1067);
            KeyTable.Add(68, 1068);
            KeyTable.Add(69, 1069);
            KeyTable.Add(70, 1070);
            KeyTable.Add(71, 1071);
            KeyTable.Add(72, 1072);
            KeyTable.Add(73, 1073);
            KeyTable.Add(74, 1074);
            KeyTable.Add(75, 1075);
            KeyTable.Add(76, 1076);
            KeyTable.Add(77, 1077);
            KeyTable.Add(78, 1078);
            KeyTable.Add(79, 1079);
            KeyTable.Add(80, 1080);
            KeyTable.Add(81, 1081);
            KeyTable.Add(82, 1082);
            KeyTable.Add(83, 1083);
            KeyTable.Add(84, 1084);
            KeyTable.Add(85, 1085);
            KeyTable.Add(86, 1086);
            KeyTable.Add(87, 1087);
            KeyTable.Add(88, 1088);
            KeyTable.Add(89, 1089);
            KeyTable.Add(90, 1090);
            KeyTable.Add(91, 1091);
            KeyTable.Add(92, 1092);
            KeyTable.Add(93, 1093);
            KeyTable.Add(94, 1094);
            KeyTable.Add(95, 1095);
            KeyTable.Add(96, 1096);
            KeyTable.Add(97, 1097);
            KeyTable.Add(98, 1098);
            KeyTable.Add(99, 1099);
            KeyTable.Add(100, 1100);
            KeyTable.Add(101, 1101);
            KeyTable.Add(102, 1102);
            KeyTable.Add(103, 1103);
            KeyTable.Add(104, 1104);
            KeyTable.Add(105, 1105);
            KeyTable.Add(106, 1106);
            KeyTable.Add(107, 1107);
            KeyTable.Add(108, 1108);
            KeyTable.Add(109, 1109);
            KeyTable.Add(110, 1110);
            KeyTable.Add(111, 1111);
            KeyTable.Add(112, 1112);
            KeyTable.Add(113, 1113);
            KeyTable.Add(114, 1114);
            KeyTable.Add(115, 1115);
            KeyTable.Add(116, 1116);
            KeyTable.Add(117, 1117);
            KeyTable.Add(118, 1118);
            KeyTable.Add(119, 1119);
            KeyTable.Add(120, 1120);
            KeyTable.Add(121, 1121);
            KeyTable.Add(122, 1122);
            KeyTable.Add(123, 1123);
            KeyTable.Add(124, 1124);
            KeyTable.Add(125, 1125);
            KeyTable.Add(126, 1126);
            KeyTable.Add(127, 1127);
            KeyTable.Add(128, 1128);
            KeyTable.Add(129, 1129);
            KeyTable.Add(130, 1130);
            KeyTable.Add(131, 1131);
            KeyTable.Add(132, 1132);
            KeyTable.Add(133, 1133);
            KeyTable.Add(134, 1134);
            KeyTable.Add(135, 1135);
            KeyTable.Add(136, 1136);
            KeyTable.Add(137, 1137);
            KeyTable.Add(138, 1138);
            KeyTable.Add(139, 1139);
            KeyTable.Add(140, 1140);
            KeyTable.Add(141, 1141);
            KeyTable.Add(142, 1142);
            KeyTable.Add(143, 1143);
            KeyTable.Add(144, 1144);
            KeyTable.Add(145, 1145);
            KeyTable.Add(146, 1146);
            KeyTable.Add(147, 1147);
            KeyTable.Add(148, 1148);
            KeyTable.Add(149, 1149);
            KeyTable.Add(150, 1150);
            KeyTable.Add(151, 1151);
            KeyTable.Add(152, 1152);
            KeyTable.Add(153, 1153);
            KeyTable.Add(154, 1154);
            KeyTable.Add(155, 1155);
            KeyTable.Add(156, 1156);
            KeyTable.Add(157, 1157);
            KeyTable.Add(158, 1158);
            KeyTable.Add(159, 1159);
            KeyTable.Add(160, 1160);
            KeyTable.Add(161, 1161);
            KeyTable.Add(162, 1162);
            KeyTable.Add(163, 1163);
            KeyTable.Add(164, 1164);
            KeyTable.Add(165, 1165);
            KeyTable.Add(166, 1166);
            KeyTable.Add(167, 1167);
            KeyTable.Add(168, 1168);
            KeyTable.Add(169, 1169);
            KeyTable.Add(170, 1170);
            KeyTable.Add(171, 1171);
            KeyTable.Add(172, 1172);
            KeyTable.Add(173, 1173);
            KeyTable.Add(174, 1174);
            KeyTable.Add(175, 1175);
            KeyTable.Add(176, 1176);
            KeyTable.Add(177, 1177);
            KeyTable.Add(178, 1178);
            KeyTable.Add(179, 1179);
            KeyTable.Add(180, 1180);
            KeyTable.Add(181, 1181);
            KeyTable.Add(182, 1182);
            KeyTable.Add(183, 1183);
            KeyTable.Add(184, 1184);
            KeyTable.Add(185, 1185);
            KeyTable.Add(186, 1186);
            KeyTable.Add(187, 1187);
            KeyTable.Add(188, 1188);
            KeyTable.Add(189, 1189);
            KeyTable.Add(190, 1190);
            KeyTable.Add(191, 1191);
            KeyTable.Add(192, 1192);
            KeyTable.Add(193, 1193);
            KeyTable.Add(194, 1194);
            KeyTable.Add(195, 1195);
            KeyTable.Add(196, 1196);
            KeyTable.Add(197, 1197);
            KeyTable.Add(198, 1198);
            KeyTable.Add(199, 1199);
            KeyTable.Add(200, 1200);
            KeyTable.Add(201, 1201);
            KeyTable.Add(202, 1202);
            KeyTable.Add(203, 1203);
            KeyTable.Add(204, 1204);
            KeyTable.Add(205, 1205);
            KeyTable.Add(206, 1206);
            KeyTable.Add(207, 1207);
            KeyTable.Add(208, 1208);
            KeyTable.Add(209, 1209);
            KeyTable.Add(210, 1210);
            KeyTable.Add(211, 1211);
            KeyTable.Add(212, 1212);
            KeyTable.Add(213, 1213);
            KeyTable.Add(214, 1214);
            KeyTable.Add(215, 1215);
            KeyTable.Add(216, 1216);
            KeyTable.Add(217, 1217);
            KeyTable.Add(218, 1218);
            KeyTable.Add(219, 1219);
            KeyTable.Add(220, 1220);
            KeyTable.Add(221, 1221);
            KeyTable.Add(222, 1222);
            KeyTable.Add(223, 1223);
            KeyTable.Add(224, 1224);
            KeyTable.Add(225, 1225);
            KeyTable.Add(226, 1226);
            KeyTable.Add(227, 1227);
            KeyTable.Add(228, 1228);
            KeyTable.Add(229, 1229);
            KeyTable.Add(230, 1230);
            KeyTable.Add(231, 1231);
            KeyTable.Add(232, 1232);
            KeyTable.Add(233, 1233);
            KeyTable.Add(234, 1234);
            KeyTable.Add(235, 1235);
            KeyTable.Add(236, 1236);
            KeyTable.Add(237, 1237);
            KeyTable.Add(238, 1238);
            KeyTable.Add(239, 1239);
            KeyTable.Add(240, 1240);
            KeyTable.Add(241, 1241);
            KeyTable.Add(242, 1242);
            KeyTable.Add(243, 1243);
            KeyTable.Add(244, 1244);
            KeyTable.Add(245, 1245);
            KeyTable.Add(246, 1246);
            KeyTable.Add(247, 1247);
            KeyTable.Add(248, 1248);
            KeyTable.Add(249, 1249);
            KeyTable.Add(250, 1250);
            KeyTable.Add(251, 1251);
            KeyTable.Add(252, 1252);
            KeyTable.Add(253, 1253);
            KeyTable.Add(254, 1254);
            KeyTable.Add(255, 1255);
            KeyTable.Add(256, 1256);
            KeyTable.Add(257, 1257);
            KeyTable.Add(258, 1258);
            KeyTable.Add(259, 1259);
            KeyTable.Add(260, 1260);
            KeyTable.Add(261, 1261);
            KeyTable.Add(262, 1262);
            KeyTable.Add(263, 1263);
            KeyTable.Add(264, 1264);
            KeyTable.Add(265, 1265);
            KeyTable.Add(266, 1266);
            KeyTable.Add(267, 1267);
            KeyTable.Add(268, 1268);
            KeyTable.Add(269, 1269);
            KeyTable.Add(270, 1270);
            KeyTable.Add(271, 1271);
            KeyTable.Add(272, 1272);
            KeyTable.Add(273, 1273);
            KeyTable.Add(274, 1274);
            KeyTable.Add(275, 1275);
            KeyTable.Add(276, 1276);
            KeyTable.Add(277, 1277);
            KeyTable.Add(278, 1278);
            KeyTable.Add(279, 1279);
            KeyTable.Add(280, 1280);
            KeyTable.Add(281, 1281);
            KeyTable.Add(282, 1282);
            KeyTable.Add(283, 1283);
            KeyTable.Add(284, 1284);
            KeyTable.Add(285, 1285);
            KeyTable.Add(286, 1286);
            KeyTable.Add(287, 1287);
            KeyTable.Add(288, 1288);
            KeyTable.Add(289, 1289);
            KeyTable.Add(290, 1290);
            KeyTable.Add(291, 1291);
            KeyTable.Add(292, 1292);
            KeyTable.Add(293, 1293);
            KeyTable.Add(294, 1294);
            KeyTable.Add(295, 1295);
            KeyTable.Add(296, 1296);
            KeyTable.Add(297, 1297);
            KeyTable.Add(298, 1298);
            KeyTable.Add(299, 1299);
            KeyTable.Add(300, 1300);
            KeyTable.Add(301, 1301);
            KeyTable.Add(302, 1302);
            KeyTable.Add(303, 1303);
            KeyTable.Add(304, 1304);
            KeyTable.Add(305, 1305);
            KeyTable.Add(306, 1306);
            KeyTable.Add(307, 1307);
            KeyTable.Add(308, 1308);
            KeyTable.Add(309, 1309);
            KeyTable.Add(310, 1310);

            KeyTable.Add(1001, 1);
            KeyTable.Add(1002, 2);
            KeyTable.Add(1003, 3);
            KeyTable.Add(1004, 4);
            KeyTable.Add(1005, 5);
            KeyTable.Add(1006, 6);
            KeyTable.Add(1007, 7);
            KeyTable.Add(1008, 8);
            KeyTable.Add(1009, 9);
            KeyTable.Add(1010, 10);
            KeyTable.Add(1011, 11);
            KeyTable.Add(1012, 12);
            KeyTable.Add(1013, 13);
            KeyTable.Add(1014, 14);
            KeyTable.Add(1015, 15);
            KeyTable.Add(1016, 16);
            KeyTable.Add(1017, 17);
            KeyTable.Add(1018, 18);
            KeyTable.Add(1019, 19);
            KeyTable.Add(1020, 20);
            KeyTable.Add(1021, 21);
            KeyTable.Add(1022, 22);
            KeyTable.Add(1023, 23);
            KeyTable.Add(1024, 24);
            KeyTable.Add(1025, 25);
            KeyTable.Add(1026, 26);
            KeyTable.Add(1027, 27);
            KeyTable.Add(1028, 28);
            KeyTable.Add(1029, 29);
            KeyTable.Add(1030, 30);
            KeyTable.Add(1031, 31);
            KeyTable.Add(1032, 32);
            KeyTable.Add(1033, 33);
            KeyTable.Add(1034, 34);
            KeyTable.Add(1035, 35);
            KeyTable.Add(1036, 36);
            KeyTable.Add(1037, 37);
            KeyTable.Add(1038, 38);
            KeyTable.Add(1039, 39);
            KeyTable.Add(1040, 40);
            KeyTable.Add(1041, 41);
            KeyTable.Add(1042, 42);
            KeyTable.Add(1043, 43);
            KeyTable.Add(1044, 44);
            KeyTable.Add(1045, 45);
            KeyTable.Add(1046, 46);
            KeyTable.Add(1047, 47);
            KeyTable.Add(1048, 48);
            KeyTable.Add(1049, 49);
            KeyTable.Add(1050, 50);
            KeyTable.Add(1051, 51);
            KeyTable.Add(1052, 52);
            KeyTable.Add(1053, 53);
            KeyTable.Add(1054, 54);
            KeyTable.Add(1055, 55);
            KeyTable.Add(1056, 56);
            KeyTable.Add(1057, 57);
            KeyTable.Add(1058, 58);
            KeyTable.Add(1059, 59);
            KeyTable.Add(1060, 60);
            KeyTable.Add(1061, 61);
            KeyTable.Add(1062, 62);
            KeyTable.Add(1063, 63);
            KeyTable.Add(1064, 64);
            KeyTable.Add(1065, 65);
            KeyTable.Add(1066, 66);
            KeyTable.Add(1067, 67);
            KeyTable.Add(1068, 68);
            KeyTable.Add(1069, 69);
            KeyTable.Add(1070, 70);
            KeyTable.Add(1071, 71);
            KeyTable.Add(1072, 72);
            KeyTable.Add(1073, 73);
            KeyTable.Add(1074, 74);
            KeyTable.Add(1075, 75);
            KeyTable.Add(1076, 76);
            KeyTable.Add(1077, 77);
            KeyTable.Add(1078, 78);
            KeyTable.Add(1079, 79);
            KeyTable.Add(1080, 80);
            KeyTable.Add(1081, 81);
            KeyTable.Add(1082, 82);
            KeyTable.Add(1083, 83);
            KeyTable.Add(1084, 84);
            KeyTable.Add(1085, 85);
            KeyTable.Add(1086, 86);
            KeyTable.Add(1087, 87);
            KeyTable.Add(1088, 88);
            KeyTable.Add(1089, 89);
            KeyTable.Add(1090, 90);
            KeyTable.Add(1091, 91);
            KeyTable.Add(1092, 92);
            KeyTable.Add(1093, 93);
            KeyTable.Add(1094, 94);
            KeyTable.Add(1095, 95);
            KeyTable.Add(1096, 96);
            KeyTable.Add(1097, 97);
            KeyTable.Add(1098, 98);
            KeyTable.Add(1099, 99);
            KeyTable.Add(1100, 100);
            KeyTable.Add(1101, 101);
            KeyTable.Add(1102, 102);
            KeyTable.Add(1103, 103);
            KeyTable.Add(1104, 104);
            KeyTable.Add(1105, 105);
            KeyTable.Add(1106, 106);
            KeyTable.Add(1107, 107);
            KeyTable.Add(1108, 108);
            KeyTable.Add(1109, 109);
            KeyTable.Add(1110, 110);
            KeyTable.Add(1111, 111);
            KeyTable.Add(1112, 112);
            KeyTable.Add(1113, 113);
            KeyTable.Add(1114, 114);
            KeyTable.Add(1115, 115);
            KeyTable.Add(1116, 116);
            KeyTable.Add(1117, 117);
            KeyTable.Add(1118, 118);
            KeyTable.Add(1119, 119);
            KeyTable.Add(1120, 120);
            KeyTable.Add(1121, 121);
            KeyTable.Add(1122, 122);
            KeyTable.Add(1123, 123);
            KeyTable.Add(1124, 124);
            KeyTable.Add(1125, 125);
            KeyTable.Add(1126, 126);
            KeyTable.Add(1127, 127);
            KeyTable.Add(1128, 128);
            KeyTable.Add(1129, 129);
            KeyTable.Add(1130, 130);
            KeyTable.Add(1131, 131);
            KeyTable.Add(1132, 132);
            KeyTable.Add(1133, 133);
            KeyTable.Add(1134, 134);
            KeyTable.Add(1135, 135);
            KeyTable.Add(1136, 136);
            KeyTable.Add(1137, 137);
            KeyTable.Add(1138, 138);
            KeyTable.Add(1139, 139);
            KeyTable.Add(1140, 140);
            KeyTable.Add(1141, 141);
            KeyTable.Add(1142, 142);
            KeyTable.Add(1143, 143);
            KeyTable.Add(1144, 144);
            KeyTable.Add(1145, 145);
            KeyTable.Add(1146, 146);
            KeyTable.Add(1147, 147);
            KeyTable.Add(1148, 148);
            KeyTable.Add(1149, 149);
            KeyTable.Add(1150, 150);
            KeyTable.Add(1151, 151);
            KeyTable.Add(1152, 152);
            KeyTable.Add(1153, 153);
            KeyTable.Add(1154, 154);
            KeyTable.Add(1155, 155);
            KeyTable.Add(1156, 156);
            KeyTable.Add(1157, 157);
            KeyTable.Add(1158, 158);
            KeyTable.Add(1159, 159);
            KeyTable.Add(1160, 160);
            KeyTable.Add(1161, 161);
            KeyTable.Add(1162, 162);
            KeyTable.Add(1163, 163);
            KeyTable.Add(1164, 164);
            KeyTable.Add(1165, 165);
            KeyTable.Add(1166, 166);
            KeyTable.Add(1167, 167);
            KeyTable.Add(1168, 168);
            KeyTable.Add(1169, 169);
            KeyTable.Add(1170, 170);
            KeyTable.Add(1171, 171);
            KeyTable.Add(1172, 172);
            KeyTable.Add(1173, 173);
            KeyTable.Add(1174, 174);
            KeyTable.Add(1175, 175);
            KeyTable.Add(1176, 176);
            KeyTable.Add(1177, 177);
            KeyTable.Add(1178, 178);
            KeyTable.Add(1179, 179);
            KeyTable.Add(1180, 180);
            KeyTable.Add(1181, 181);
            KeyTable.Add(1182, 182);
            KeyTable.Add(1183, 183);
            KeyTable.Add(1184, 184);
            KeyTable.Add(1185, 185);
            KeyTable.Add(1186, 186);
            KeyTable.Add(1187, 187);
            KeyTable.Add(1188, 188);
            KeyTable.Add(1189, 189);
            KeyTable.Add(1190, 190);
            KeyTable.Add(1191, 191);
            KeyTable.Add(1192, 192);
            KeyTable.Add(1193, 193);
            KeyTable.Add(1194, 194);
            KeyTable.Add(1195, 195);
            KeyTable.Add(1196, 196);
            KeyTable.Add(1197, 197);
            KeyTable.Add(1198, 198);
            KeyTable.Add(1199, 199);
            KeyTable.Add(1200, 200);
            KeyTable.Add(1201, 201);
            KeyTable.Add(1202, 202);
            KeyTable.Add(1203, 203);
            KeyTable.Add(1204, 204);
            KeyTable.Add(1205, 205);
            KeyTable.Add(1206, 206);
            KeyTable.Add(1207, 207);
            KeyTable.Add(1208, 208);
            KeyTable.Add(1209, 209);
            KeyTable.Add(1210, 210);
            KeyTable.Add(1211, 211);
            KeyTable.Add(1212, 212);
            KeyTable.Add(1213, 213);
            KeyTable.Add(1214, 214);
            KeyTable.Add(1215, 215);
            KeyTable.Add(1216, 216);
            KeyTable.Add(1217, 217);
            KeyTable.Add(1218, 218);
            KeyTable.Add(1219, 219);
            KeyTable.Add(1220, 220);
            KeyTable.Add(1221, 221);
            KeyTable.Add(1222, 222);
            KeyTable.Add(1223, 223);
            KeyTable.Add(1224, 224);
            KeyTable.Add(1225, 225);
            KeyTable.Add(1226, 226);
            KeyTable.Add(1227, 227);
            KeyTable.Add(1228, 228);
            KeyTable.Add(1229, 229);
            KeyTable.Add(1230, 230);
            KeyTable.Add(1231, 231);
            KeyTable.Add(1232, 232);
            KeyTable.Add(1233, 233);
            KeyTable.Add(1234, 234);
            KeyTable.Add(1235, 235);
            KeyTable.Add(1236, 236);
            KeyTable.Add(1237, 237);
            KeyTable.Add(1238, 238);
            KeyTable.Add(1239, 239);
            KeyTable.Add(1240, 240);
            KeyTable.Add(1241, 241);
            KeyTable.Add(1242, 242);
            KeyTable.Add(1243, 243);
            KeyTable.Add(1244, 244);
            KeyTable.Add(1245, 245);
            KeyTable.Add(1246, 246);
            KeyTable.Add(1247, 247);
            KeyTable.Add(1248, 248);
            KeyTable.Add(1249, 249);
            KeyTable.Add(1250, 250);
            KeyTable.Add(1251, 251);
            KeyTable.Add(1252, 252);
            KeyTable.Add(1253, 253);
            KeyTable.Add(1254, 254);
            KeyTable.Add(1255, 255);
            KeyTable.Add(1256, 256);
            KeyTable.Add(1257, 257);
            KeyTable.Add(1258, 258);
            KeyTable.Add(1259, 259);
            KeyTable.Add(1260, 260);
            KeyTable.Add(1261, 261);
            KeyTable.Add(1262, 262);
            KeyTable.Add(1263, 263);
            KeyTable.Add(1264, 264);
            KeyTable.Add(1265, 265);
            KeyTable.Add(1266, 266);
            KeyTable.Add(1267, 267);
            KeyTable.Add(1268, 268);
            KeyTable.Add(1269, 269);
            KeyTable.Add(1270, 270);
            KeyTable.Add(1271, 271);
            KeyTable.Add(1272, 272);
            KeyTable.Add(1273, 273);
            KeyTable.Add(1274, 274);
            KeyTable.Add(1275, 275);
            KeyTable.Add(1276, 276);
            KeyTable.Add(1277, 277);
            KeyTable.Add(1278, 278);
            KeyTable.Add(1279, 279);
            KeyTable.Add(1280, 280);
            KeyTable.Add(1281, 281);
            KeyTable.Add(1282, 282);
            KeyTable.Add(1283, 283);
            KeyTable.Add(1284, 284);
            KeyTable.Add(1285, 285);
            KeyTable.Add(1286, 286);
            KeyTable.Add(1287, 287);
            KeyTable.Add(1288, 288);
            KeyTable.Add(1289, 289);
            KeyTable.Add(1290, 290);
            KeyTable.Add(1291, 291);
            KeyTable.Add(1292, 292);
            KeyTable.Add(1293, 293);
            KeyTable.Add(1294, 294);
            KeyTable.Add(1295, 295);
            KeyTable.Add(1296, 296);
            KeyTable.Add(1297, 297);
            KeyTable.Add(1298, 298);
            KeyTable.Add(1299, 299);
            KeyTable.Add(1300, 300);
            KeyTable.Add(1301, 301);
            KeyTable.Add(1302, 302);
            KeyTable.Add(1303, 303);
            KeyTable.Add(1304, 304);
            KeyTable.Add(1305, 305);
            KeyTable.Add(1306, 306);
            KeyTable.Add(1307, 307);
            KeyTable.Add(1308, 308);
            KeyTable.Add(1309, 309);
            KeyTable.Add(1310, 310);




            /*foreach (KeyValuePair<int, int> key in KeyTable)
            {
                int valuePair = valueInput;
            }
            TODO: Variablen key und value definieren*/
        }
    }
}
