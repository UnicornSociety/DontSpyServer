using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static ModernEncryption.Intervals;

namespace ModernEncryption
{
    public class Symbol
    {
        public char symbol { get; }
        public string Chiffre { get;  set; }

 
        public Symbol(char symbol)
        {
            this.symbol = symbol;
            var interval = IntervalAssignment();
            var randomNumber = SelectRandomIntervalNumber(interval);
            //Debug.WriteLine(randomNumber);
            var chiffre = Permutation(randomNumber);
            Chiffre = Transformation(chiffre);
        }

        public Interval IntervalAssignment()
        {
            return IntervalTable[symbol];
        }

        public int SelectRandomIntervalNumber(Interval interval)
        {
            Random rnd = new Random();
            return rnd.Next(interval.Start, interval.End + 1);
        }

        public string Transformation(int randomNumber)
        {

            //TODO Rückübersetzung von Zahl in Zeichenpaar

            var keyA = (randomNumber - 1) / 40 + 1;
            var keyB = (randomNumber - 1) % 40 + 1;
            char chiffreSplit1 = TransformationTable.transformationTable[keyA];
            char chiffreSplit2 = TransformationTable.transformationTable[keyB];
            return "" + chiffreSplit1 + chiffreSplit2;
        }

        /*public int KeyDataReadIn()
         {
            int keyInput = Console.ReadLine();
            int keyInput;
           /keyInput = 3;
            return keyInput;
        }*/

        /*public int ValueOfKeyDataReadIn()
        {
            int valueInput = Console.ReadLine();
            int valueInput;
            valueInput = 3;
            return valueInput;
        }*/

        public static Dictionary<int, int> KeyTable  = new Dictionary<int, int>();
        public void Value(int valueInput)
        {
            KeyTable.Add(4, 21);
            KeyTable.Add(10, 22);
            KeyTable.Add(11, 23);
            KeyTable.Add(17, 24);
            KeyTable.Add(12, 25);
            KeyTable.Add(5, 26);
            KeyTable.Add(1, 27);
            KeyTable.Add(9, 28);
            KeyTable.Add(7, 29);
            KeyTable.Add(18, 30);
            KeyTable.Add(6, 31);
            KeyTable.Add(3, 32);
            KeyTable.Add(15, 33);
            KeyTable.Add(19, 34);
            KeyTable.Add(14, 35);
            KeyTable.Add(16, 36);
            KeyTable.Add(8, 37);
            KeyTable.Add(2, 38);
            KeyTable.Add(13, 39);
            KeyTable.Add(20, 40);
            KeyTable.Add(21, 4);
            KeyTable.Add(22, 10);
            KeyTable.Add(23, 11);
            KeyTable.Add(24, 17);
            KeyTable.Add(25, 12);
            KeyTable.Add(26, 5);
            KeyTable.Add(27, 1);
            KeyTable.Add(28, 9);
            KeyTable.Add(29, 7);
            KeyTable.Add(30, 18);
            KeyTable.Add(31, 6);
            KeyTable.Add(32, 3);
            KeyTable.Add(33, 15);
            KeyTable.Add(34, 19);
            KeyTable.Add(35, 14);
            KeyTable.Add(36, 16);
            KeyTable.Add(37, 8);
            KeyTable.Add(38, 2);
            KeyTable.Add(39, 13);
            KeyTable.Add(40, 20);
            KeyTable.Add(41, 71);
            KeyTable.Add(42, 72);
            KeyTable.Add(43, 73);
            KeyTable.Add(44, 74);
            KeyTable.Add(45, 75);
            KeyTable.Add(46, 76);
            KeyTable.Add(47, 77);
            KeyTable.Add(48, 78);
            KeyTable.Add(49, 79);
            KeyTable.Add(50, 80);
            KeyTable.Add(51, 81);
            KeyTable.Add(52, 82);
            KeyTable.Add(53, 83);
            KeyTable.Add(54, 84);
            KeyTable.Add(55, 85);
            KeyTable.Add(56, 86);
            KeyTable.Add(57, 87);
            KeyTable.Add(58, 88);
            KeyTable.Add(59, 89);
            KeyTable.Add(60, 90);
            KeyTable.Add(61, 91);
            KeyTable.Add(62, 92);
            KeyTable.Add(63, 93);
            KeyTable.Add(64, 94);
            KeyTable.Add(65, 95);
            KeyTable.Add(66, 96);
            KeyTable.Add(67, 97);
            KeyTable.Add(68, 98);
            KeyTable.Add(69, 99);
            KeyTable.Add(70, 100);
            KeyTable.Add(71, 41);
            KeyTable.Add(72, 42);
            KeyTable.Add(73, 43);
            KeyTable.Add(74, 44);
            KeyTable.Add(75, 45);
            KeyTable.Add(76, 46);
            KeyTable.Add(77, 47);
            KeyTable.Add(78, 48);
            KeyTable.Add(79, 49);
            KeyTable.Add(80, 50);
            KeyTable.Add(81, 51);
            KeyTable.Add(82, 52);
            KeyTable.Add(83, 53);
            KeyTable.Add(84, 54);
            KeyTable.Add(85, 55);
            KeyTable.Add(86, 56);
            KeyTable.Add(87, 57);
            KeyTable.Add(88, 58);
            KeyTable.Add(89, 59);
            KeyTable.Add(90, 60);
            KeyTable.Add(91, 61);
            KeyTable.Add(92, 62);
            KeyTable.Add(93, 63);
            KeyTable.Add(94, 64);
            KeyTable.Add(95, 65);
            KeyTable.Add(96, 66);
            KeyTable.Add(97, 67);
            KeyTable.Add(98, 68);
            KeyTable.Add(99, 69);
            KeyTable.Add(100, 70);

            KeyTable.Add(101, 263);
            KeyTable.Add(102, 264);
            KeyTable.Add(103, 265);
            KeyTable.Add(104, 273);
            KeyTable.Add(105, 250);
            KeyTable.Add(106, 251);
            KeyTable.Add(107, 252);
            KeyTable.Add(108, 253);
            KeyTable.Add(109, 254);
            KeyTable.Add(110, 255);
            KeyTable.Add(111, 256);
            KeyTable.Add(112, 274);
            KeyTable.Add(113, 275);
            KeyTable.Add(114, 299);
            KeyTable.Add(115, 300);
            KeyTable.Add(116, 301);
            KeyTable.Add(117, 302);
            KeyTable.Add(118, 303);
            KeyTable.Add(119, 304);
            KeyTable.Add(120, 305);
            KeyTable.Add(121, 306);
            KeyTable.Add(122, 307);
            KeyTable.Add(123, 308);
            KeyTable.Add(124, 309);
            KeyTable.Add(125, 310);
            KeyTable.Add(126, 112);
            KeyTable.Add(127, 113);
            KeyTable.Add(128, 114);
            KeyTable.Add(129, 115);
            KeyTable.Add(130, 116);
            KeyTable.Add(131, 117);
            KeyTable.Add(132, 118);
            KeyTable.Add(133, 119);
            KeyTable.Add(134, 120);
            KeyTable.Add(135, 121);
            KeyTable.Add(136, 122);
            KeyTable.Add(137, 107);
            KeyTable.Add(138, 292);
            KeyTable.Add(139, 101);
            KeyTable.Add(140, 102);
            KeyTable.Add(141, 103);
            KeyTable.Add(142, 104);
            KeyTable.Add(143, 105);
            KeyTable.Add(144, 106);
            KeyTable.Add(145, 286);
            KeyTable.Add(146, 108);
            KeyTable.Add(147, 109);
            KeyTable.Add(148,  110);
            KeyTable.Add(149, 111);
            KeyTable.Add(150, 289);
            KeyTable.Add(151, 288);
            KeyTable.Add(152, 188);
            KeyTable.Add(153, 189);
            KeyTable.Add(154, 190);
            KeyTable.Add(155, 191);
            KeyTable.Add(156, 192);
            KeyTable.Add(157, 193);
            KeyTable.Add(158, 194);
            KeyTable.Add(159, 195);
            KeyTable.Add(160, 287);
            KeyTable.Add(161, 123);
            KeyTable.Add(162, 124);
            KeyTable.Add(163, 125);
            KeyTable.Add(164  ,   126);
            KeyTable.Add(165, 127);
            KeyTable.Add(166, 128);
            KeyTable.Add(167, 129);
            KeyTable.Add(168, 130);
            KeyTable.Add(169, 131);
            KeyTable.Add(170, 132);
            KeyTable.Add(171, 133);
            KeyTable.Add(172, 134);
            KeyTable.Add(173, 135);
            KeyTable.Add(174, 136);
            KeyTable.Add(175, 137);
            KeyTable.Add(176, 138);
            KeyTable.Add(177, 139);
            KeyTable.Add(178, 140);
            KeyTable.Add(179, 141);
            KeyTable.Add(180,     142);
            KeyTable.Add(181, 143);
            KeyTable.Add(182, 144);
            KeyTable.Add(183, 145);
            KeyTable.Add(184, 146);
            KeyTable.Add(185, 147);
            KeyTable.Add(186, 148);
            KeyTable.Add(187, 149);
            KeyTable.Add(188, 150);
            KeyTable.Add(189, 151);
            KeyTable.Add(190, 152);
            KeyTable.Add(191, 153);
            KeyTable.Add(192, 154);
            KeyTable.Add(193, 155);
            KeyTable.Add(194, 156);
            KeyTable.Add(195, 157);
            KeyTable.Add(196 ,    158);
            KeyTable.Add(197, 159);
            KeyTable.Add(198, 160);
            KeyTable.Add(199, 161);
            KeyTable.Add(200, 162);
            KeyTable.Add(201, 163);
            KeyTable.Add(202, 164);
            KeyTable.Add(203, 165);
            KeyTable.Add(204, 166);
            KeyTable.Add(205, 167);
            KeyTable.Add(206, 168);
            KeyTable.Add(207, 169);
            KeyTable.Add(208, 170);
            KeyTable.Add(209, 171);
            KeyTable.Add(210, 172);
            KeyTable.Add(211, 173);
            KeyTable.Add(212  ,   174);
            KeyTable.Add(213, 175);
            KeyTable.Add(214, 176);
            KeyTable.Add(215, 177);
            KeyTable.Add(216, 178);
            KeyTable.Add(217, 179);
            KeyTable.Add(218, 180);
            KeyTable.Add(219, 181);
            KeyTable.Add(220, 182);
            KeyTable.Add(221, 183);
            KeyTable.Add(222, 184);
            KeyTable.Add(223, 185);
            KeyTable.Add(224, 186);
            KeyTable.Add(225, 187);
            KeyTable.Add(226, 213);
            KeyTable.Add(227, 214);
            KeyTable.Add(228   ,  215);
            KeyTable.Add(229, 216);
            KeyTable.Add(230, 217);
            KeyTable.Add(231, 218);
            KeyTable.Add(232, 219);
            KeyTable.Add(233, 220);
            KeyTable.Add(234, 196);
            KeyTable.Add(235, 197);
            KeyTable.Add(236, 198);
            KeyTable.Add(237, 199);
            KeyTable.Add(238, 200);
            KeyTable.Add(239, 201);
            KeyTable.Add(240, 202);
            KeyTable.Add(241, 203);
            KeyTable.Add(242, 204);
            KeyTable.Add(243, 205);
            KeyTable.Add(244    , 206);
            KeyTable.Add(245, 207);
            KeyTable.Add(246, 208);
            KeyTable.Add(247, 209);
            KeyTable.Add(248, 298);
            KeyTable.Add(249, 290);
            KeyTable.Add(250, 291);
            KeyTable.Add(251, 221);
            KeyTable.Add(252, 222);
            KeyTable.Add(253, 223);
            KeyTable.Add(254, 224);
            KeyTable.Add(255, 225);
            KeyTable.Add(256, 226);
            KeyTable.Add(257, 227);
            KeyTable.Add(258, 228);
            KeyTable.Add(259, 229);
            KeyTable.Add(260,     230);
            KeyTable.Add(261, 231);
            KeyTable.Add(262, 210);
            KeyTable.Add(263, 211);
            KeyTable.Add(264, 212);
            KeyTable.Add(265, 293);
            KeyTable.Add(266, 294);
            KeyTable.Add(267, 295);
            KeyTable.Add(268, 296);
            KeyTable.Add(269, 297);
            KeyTable.Add(270, 232);
            KeyTable.Add(271, 233);
            KeyTable.Add(272, 234);
            KeyTable.Add(273, 235);
            KeyTable.Add(274, 236);
            KeyTable.Add(275, 237);
            KeyTable.Add(276 ,    238);
            KeyTable.Add(277, 239);
            KeyTable.Add(278, 240);
            KeyTable.Add(279, 241);
            KeyTable.Add(280, 242);
            KeyTable.Add(281, 243);
            KeyTable.Add(282, 244);
            KeyTable.Add(283, 245);
            KeyTable.Add(284, 246);
            KeyTable.Add(285, 247);
            KeyTable.Add(286, 248);
            KeyTable.Add(287, 249);
            KeyTable.Add(288, 266);
            KeyTable.Add(289, 267);
            KeyTable.Add(290, 268);
            KeyTable.Add(291, 269);
            KeyTable.Add(292, 270);
            KeyTable.Add(293, 271);
            KeyTable.Add(294, 272);
            KeyTable.Add(295, 257);
            KeyTable.Add(296, 258);
            KeyTable.Add(297, 259);
            KeyTable.Add(298, 260);
            KeyTable.Add(299, 261);
            KeyTable.Add(300, 262);
            KeyTable.Add(301, 276);
            KeyTable.Add(302, 277);
            KeyTable.Add(303, 278);
            KeyTable.Add(304, 279);
            KeyTable.Add(305, 280);
            KeyTable.Add(306, 281);
            KeyTable.Add(307, 282);
            KeyTable.Add(308 ,    283);
            KeyTable.Add(309, 284);
            KeyTable.Add(310, 285);


            /*foreach (KeyValuePair<int, int> key in KeyTable)
            {
                int valuePair = valueInput;
            }
            TODO: Variablen key und value definieren*/
        }

        //Encryption
        public int Permutation(int randomNumber)
            {
                /*for (randomNumber = 0; randomNumber < 100; randomNumber++)
                {*/
                    if (KeyTable.ContainsKey(randomNumber))
                    {
                        randomNumber = KeyTable[randomNumber];
                        //return randomNumber;
                    }
                //}
                //return 1;
                return randomNumber;
            }

            //Decryption
            public int BackPermutation(int value)
            {
                for (value = 0; value < 100; value++ )
                    {
                        if (KeyTable.ContainsKey(value))
                        {
                            value = KeyTable[value];
                            return value;
                        }
                    }
                return 1; 
            }



    }
}
