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
            var a = new Interval(1, 360);

            var b = new Interval(361, 469);

            var c = new Interval(470, 651);

            var d = new Interval(652, 947);

            var e = new Interval(948, 1913);

            var f = new Interval(1914, 2008);

            var g = new Interval(2009, 2185);

            var h = new Interval(2186, 2467);

            var i = new Interval(2468, 2913);

            var j = new Interval(2914, 2926);

            var k = new Interval(2927, 2994);

            var l = new Interval(2995, 3194);

            var m = new Interval(3195, 3339);

            var n = new Interval(3340, 3917);

            var o = new Interval(3918, 4042);

            var p = new Interval(4043, 4087);

            var q = new Interval(4088, 4091);

            var r = new Interval(4092, 4505);

            var s = new Interval(4506, 4933);

            var t = new Interval(4934, 5297);

            var u = new Interval(5298, 5532);

            var v = new Interval(5533, 5568);

            var w = new Interval(5569, 5677);

            var x = new Interval(5678, 5681);

            var y = new Interval(5682, 5685);

            var z = new Interval(5686, 5748);

            var sharpS = new Interval(5749, 5768);

            var ä = new Interval(5769, 5818);

            var ö = new Interval(5819, 5868);

            var ü = new Interval(5869, 5918);

            var A = new Interval(5919, 5960);

            var B = new Interval(5961, 5972);

            var C = new Interval(5973, 5992);

            var D = new Interval(5993, 6024);

            var E = new Interval(6025, 6130);

            var F = new Interval(6131, 6140);

            var G = new Interval(6141, 6159);

            var H = new Interval(6160, 6191);

            var I = new Interval(6192, 6240);

            var J = new Interval(6241, 6242);

            var K = new Interval(6243, 6249);

            var L = new Interval(6250, 6271);

            var M = new Interval(6272, 6287);

            var N = new Interval(6288, 6351);

            var O = new Interval(6352, 6367);

            var P = new Interval(6368, 6372);

            var Q = new Interval(6373, 6374);

            var R = new Interval(6375, 6420);

            var S = new Interval(6421, 6467);

            var T = new Interval(6468, 6507);

            var U = new Interval(6508, 6535);

            var V = new Interval(6536, 6539);

            var W = new Interval(6540, 6551);

            var X = new Interval(6552, 6553);

            var Y = new Interval(6554, 6555);

            var Z = new Interval(6556, 6562);

            var Ä = new Interval(6563, 6567);

            var Ö = new Interval(6568, 6572);

            var Ü = new Interval(6573, 6577);

            var one = new Interval(6578, 6579);

            var two = new Interval(6580, 6581);

            var three = new Interval(6582, 6583);

            var four = new Interval(6584, 6585);

            var five = new Interval(6586, 6587);
            
            var six = new Interval(6588, 6589);
            
            var seven = new Interval(6590, 6591);
            
            var eight = new Interval(6592, 6593);
            
            var nine = new Interval(6594, 6595);
            
            var zero = new Interval(6596, 6597);
            
            var dot = new Interval(6598, 6678);
            
            var comma = new Interval(6679, 6794);
            
            var space = new Interval(6795, 8064);
            
            var fragez = new Interval(8065, 8066);
            
            var ausrufez = new Interval(8067, 8068);
            
            var plus = new Interval(8069, 8070);
            
            var minus = new Interval(8071, 8072);
            
            var mal = new Interval(8073, 8074);
            
            var slash = new Interval(8075, 8076);
            
            var semikolon = new Interval(8077, 8078);
            
            var doppelp = new Interval(8079, 8080);
            
            var paragraph = new Interval(8081, 8082);
            
            var prozent = new Interval(8083, 8084);
            
            var und = new Interval(8085, 8086);
            
            var euro = new Interval(8087, 8088);
            
            var klammerAuf = new Interval(8089, 8090);
            
            var klammerZu = new Interval(8091, 8092);
            
            var gleich = new Interval(8093, 8094);
            
            var hashtag = new Interval(8095, 8096);
            
            var unterstrich = new Interval(8097, 8098);
            
            var at = new Interval(8099, 8100);

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
            IntervalTable.Add('ß', sharpS);
            IntervalTable.Add('ä', ä);
            IntervalTable.Add('ö', ö);
            IntervalTable.Add('ü', ü);
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
            IntervalTable.Add('Ä', Ä);
            IntervalTable.Add('Ö', Ö);
            IntervalTable.Add('Ü', Ü);
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
            IntervalTable.Add('.', dot);
            IntervalTable.Add(',', comma);
            IntervalTable.Add(' ', space);
            IntervalTable.Add('?', fragez);
            IntervalTable.Add('!', ausrufez);
            IntervalTable.Add('+', plus);
            IntervalTable.Add('-', minus);
            IntervalTable.Add('*', mal);
            IntervalTable.Add('/', slash);
            IntervalTable.Add(';', semikolon);
            IntervalTable.Add(':', doppelp);
            IntervalTable.Add('§', paragraph);
            IntervalTable.Add('%', prozent);
            IntervalTable.Add('&', und);
            IntervalTable.Add('€', euro);
            IntervalTable.Add('(', klammerAuf);
            IntervalTable.Add(')', klammerZu);
            IntervalTable.Add('=', gleich);
            IntervalTable.Add('#', hashtag);
            IntervalTable.Add('_', unterstrich);
            IntervalTable.Add('@', at);
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
            TransformationTable.Add(28, 'ä');
            TransformationTable.Add(29, 'ö');
            TransformationTable.Add(30, 'ü');
            TransformationTable.Add(31, 'A');
            TransformationTable.Add(32, 'B');
            TransformationTable.Add(33, 'C');
            TransformationTable.Add(34, 'D');
            TransformationTable.Add(35, 'E');
            TransformationTable.Add(36, 'F');
            TransformationTable.Add(37, 'G');
            TransformationTable.Add(38, 'H');
            TransformationTable.Add(39, 'I');
            TransformationTable.Add(40, 'J');
            TransformationTable.Add(41, 'K');
            TransformationTable.Add(42, 'L');
            TransformationTable.Add(43, 'M');
            TransformationTable.Add(44, 'N');
            TransformationTable.Add(45, 'O');
            TransformationTable.Add(46, 'P');
            TransformationTable.Add(47, 'Q');
            TransformationTable.Add(48, 'R');
            TransformationTable.Add(49, 'S');
            TransformationTable.Add(50, 'T');
            TransformationTable.Add(51, 'U');
            TransformationTable.Add(52, 'V');
            TransformationTable.Add(53, 'W');
            TransformationTable.Add(54, 'X');
            TransformationTable.Add(55, 'Y');
            TransformationTable.Add(56, 'Z');
            TransformationTable.Add(57, 'Ä');
            TransformationTable.Add(58, 'Ö');
            TransformationTable.Add(59, 'Ü');
            TransformationTable.Add(60, '1');
            TransformationTable.Add(61, '2');
            TransformationTable.Add(62, '3');
            TransformationTable.Add(63, '4');
            TransformationTable.Add(64, '5');
            TransformationTable.Add(65, '6');
            TransformationTable.Add(66, '7');
            TransformationTable.Add(67, '8');
            TransformationTable.Add(68, '9');
            TransformationTable.Add(69, '0');
            TransformationTable.Add(70, '.');
            TransformationTable.Add(71, ',');
            TransformationTable.Add(72, ' ');
            TransformationTable.Add(73, '?');
            TransformationTable.Add(74, '!');
            TransformationTable.Add(75, '+');
            TransformationTable.Add(76, '-');
            TransformationTable.Add(77, '*');
            TransformationTable.Add(78, '/');
            TransformationTable.Add(79, ';');
            TransformationTable.Add(80, ':');
            TransformationTable.Add(81, '§');
            TransformationTable.Add(82, '%');
            TransformationTable.Add(83, '&');
            TransformationTable.Add(84, '€');
            TransformationTable.Add(85, '(');
            TransformationTable.Add(86, ')');
            TransformationTable.Add(87, '=');
            TransformationTable.Add(88, '#');
            TransformationTable.Add(89, '_');
            TransformationTable.Add(90, '@');
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

            



            /*foreach (KeyValuePair<int, int> key in KeyTable)
            {
                int valuePair = valueInput;
            }
            TODO: Variablen key und value definieren*/
        }
    }
}
