using System;
using System.Collections.Generic;
using System.Text;

namespace ModernEncryption
{
    public static class Intervals
    {
        // TODO: Intervallwerte in Dictionary abspeichern
        public static Dictionary<char, Interval> IntervalTable { get; set; } = new Dictionary<char, Interval>();

        public static void InitalizeIntervalTable()
        {
            var a = new Interval(1, 84);

            var b = new Interval(85, 108);

            var c = new Interval(109, 147);

            var d = new Interval(148, 213);
            
            var e = new Interval(214, 439);
            
            var f = new Interval(440, 460);
            
            var g = new Interval(461, 499);
            
            var h = new Interval(500, 561);
           
            var i = new Interval(562, 659);
           
            var j = new Interval(660, 662);
           
            var k = new Interval(663, 677);
            
            var l = new Interval(678, 721);
            
            var m = new Interval(722, 753);
            
            var n = new Interval(754, 880);
            
            var o = new Interval(881, 912);
            
            var p = new Interval(913, 922);
            
            var q = new Interval(923, 923);
            
            var r = new Interval(924, 1014);
            
            var s = new Interval(1015, 1108);
            
            var t = new Interval(1109, 1188);
            
            var u = new Interval(1189, 1244);
            
            var v = new Interval(1245, 1252);
            
            var w = new Interval(1253, 1276);
            
            var x = new Interval(1277, 1277);
            
            var y = new Interval(1278, 1278);
            
            var z = new Interval(1279, 1292);
            
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
    }

}
