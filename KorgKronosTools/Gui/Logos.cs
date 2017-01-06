// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PcgTools.Gui
{
    public class Logos : List<Logo>
    {
        public Logos()
        {
            // In same order as docs google page.
            Add(new Logo("Steve Baker", String.Empty, String.Empty, 375));
            Add(new Logo("Adrian", "imprezariat.png", "http://www.imprezariat.pl", 500));
            Add(new Logo("Yuma", String.Empty, String.Empty, 1000));
            Add(new Logo("Dreamland", "dreamland.jpg", "http://www.dreamland-recording.de", 1500)); // 2 CDs
            Add(new Logo("Toon Martens", "tmp.jpg", "http://www.toonmartensproject.net/", 1000)); // CD
            Add(new Logo("Fred Alberni/Farrokh Kouhang", String.Empty, String.Empty, 1000));
            Add(new Logo("phattbuzz", String.Empty, String.Empty, 1000));
            Add(new Logo("Wilton Vought", String.Empty, String.Empty, 1000));
            Add(new Logo("robbie50", String.Empty, String.Empty, 3500));
            Add(new Logo("Dave Gibson", String.Empty, String.Empty, 1500));
            Add(new Logo("Wan Kemper", String.Empty, String.Empty, 1500));
            Add(new Logo("Artur Dellarte", String.Empty, String.Empty, 1500));
            Add(new Logo("Michael Maschek", "celticvoyager.png", "https://www.facebook.com/celticvoyagerband", 1500));
            Add(new Logo("Jim Knopf", String.Empty, String.Empty, 2000));
            Add(new Logo("Olaf Arweiler", String.Empty, String.Empty, 2000));
            Add(new Logo("Martin Hines", String.Empty, String.Empty, 2000));
            Add(new Logo("Mathieu Maes", "cupsandplates.png", "http://partycoverband.wix.com/cupsandplates", 2000));
            Add(new Logo("Batisse", String.Empty, String.Empty, 2000));
            Add(new Logo("Traugott", String.Empty, String.Empty, 7000));
            Add(new Logo("Philip Joseph", String.Empty, String.Empty, 2500));
            Add(new Logo("Igor Elshaidt", String.Empty, String.Empty, 2500));
            Add(new Logo("Bruno Santos", String.Empty, String.Empty, 3000));
            Add(new Logo("Joe Keller", "keller12.jpg", "http://www.keller12.de", 3000));
            Add(new Logo("needamuse", String.Empty, String.Empty, 80000));
            Add(new Logo("Smyth Rocks", String.Empty, String.Empty, 10000));
            Add(new Logo("Sidney Leal", String.Empty, String.Empty, 500));
            Add(new Logo("Greg Heslington", String.Empty, String.Empty, 1500));
            Add(new Logo("Norman Clasper", String.Empty, String.Empty, 1200));
            Add(new Logo("Tim Godfrey", String.Empty, String.Empty, 1000));
            Add(new Logo("Jim G", String.Empty, String.Empty, 700));
            Add(new Logo("Jerry", String.Empty, String.Empty, 1000));
            Add(new Logo("Tim Möller", String.Empty, String.Empty, 500));
            Add(new Logo("Ralph Hopstaken", String.Empty, String.Empty, 1000));
            Add(new Logo("Kevin Nolan", String.Empty, String.Empty, 5000));
            Add(new Logo("Christian Moss", String.Empty, String.Empty, 500));
            Add(new Logo("Enrico Puglisi", "KronosPatchLab.png", "https://www.facebook.com/kronospatchlab", 1000));
            Add(new Logo("Mike Hildner", String.Empty, String.Empty, 5000));
            Add(new Logo("Miroslav Novak", String.Empty, String.Empty, 200));
            Add(new Logo("Daan Andriessen", "BK-facebook.gif", "www.studiodebovenkamer.nl", 2500));
        }


        /// <summary>
        /// Returns a random logo based on donated money.
        /// </summary>
        /// <returns></returns>
        public Logo GetRandomLogo()
        {
            var randomValue = new Random().Next(this.Sum(logo => logo.DonatedMoney));
            Thread.Sleep(10); // For the next random value (wait 10 ms, 100 ms is enough, 10 needs to be tested if needed)

            // Iterate through logos until found.
            var logoIndex = -1;
            var visitedValue = 0;

            while (true)
            {
                var logo = this[++logoIndex];
                if (visitedValue + logo.DonatedMoney > randomValue)
                {
                    break;
                }

                visitedValue += logo.DonatedMoney;
            }

            return this[logoIndex];
        }
    }
}
