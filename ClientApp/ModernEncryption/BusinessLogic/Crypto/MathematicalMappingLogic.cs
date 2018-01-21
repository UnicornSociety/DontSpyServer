using System.Collections.Generic;
using ModernEncryption.Model;

namespace ModernEncryption.BusinessLogic.Crypto
{
    internal class MathematicalMappingLogic
    {
        public static Dictionary<char, Interval> IntervalTable { get; set; } = new Dictionary<char, Interval>();
        public static Dictionary<int, char> TransformationTable { get; set; } = new Dictionary<int, char>();
        public static Dictionary<char, int> BackTransformationTable { get; set; } = new Dictionary<char, int>();

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

            var anfuehrungsstr= new Interval(8081, 8082);

            var prozent= new Interval(8083, 8084);

            var und = new Interval(8085, 8086);

            var euro= new Interval(8087, 8088);

            var klammerAuf= new Interval(8089, 8090);

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
            IntervalTable.Add('"', anfuehrungsstr);
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
            TransformationTable.Add(81, '"');
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
    }
}
