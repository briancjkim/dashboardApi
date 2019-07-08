using System;
using System.Collections.Generic;

namespace coreangular.api
{
    public class Helpers
    {
        private static Random _rand = new Random();
        private static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }
        internal static string MakeUniqueCustomerName(List<string> names)
        {
            // 12*12조합으로 이름자동생성한다 144이상일경우 에러생성
            var maxNames = bizPrefix.Count * bizSuffix.Count;
            if (names.Count >= maxNames)
            {
                throw new System.InvalidOperationException("Max number of unique names exceeded!!");
            }
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);
            var bizName = prefix + suffix;
            if (names.Contains(bizName))
            {
                MakeUniqueCustomerName(names);
            }
            return bizName;
        }
        internal static string MakeCustomerEmail(string customerName)
        {
            return $"contact@{customerName.ToLower()}.com";
        }
        internal static string GetRandomState()
        {
            return GetRandom(auStates);
        }

        private static readonly List<string> auStates = new List<string>(){
            "NSW","QLD","VIC","ACT","NT","SA","WA","Tas"
        };
        private static readonly List<string> bizPrefix = new List<string>()
        {
            "ABC","XYZ","MainSt","Sales","Enterprise","Ready","Quick","Budget","Peak","Magic","Family","Comfort"
        };
        private static readonly List<string> bizSuffix = new List<string>()
        {
            "Corporation","Co","Logistics","Transit","Bakery","Goods","Foods","Cleaners","Hotels","Planners","Automative","Books"
        };


        ////////////////////////////////////////////////// Order
        internal static DateTime GetRandomOrderPlaced()
        {
            // 지금부터 90일전까지 날짜를 랜덤으로 뽑아서
            var end = DateTime.Now;
            var start = end.AddDays(-90);
            TimeSpan possibleSpan = end - start;
            // hours minutes seconds || randomnext (min,max)
            // 최소0 최대90 일 랜덤하게 정한다.
            TimeSpan newSpan = new TimeSpan(0, _rand.Next(0, (int)possibleSpan.TotalMinutes), 0);
            return start + newSpan;
        }
        internal static DateTime? GetRandomOrderCompleted(DateTime orderPlaced)
        {
            //기존에 orderdate에서 7-14일을 더할거다.
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var timePassed = now - orderPlaced;
            if (timePassed < minLeadTime)
            {
                // order아직처리중
                return null;
            }
            // order가 처리되서 completed날짜발표
            return orderPlaced.AddDays(_rand.Next(7, 14));
        }
        internal static decimal GetRandomOrderTotal()
        {
            return _rand.Next(100);
        }
    }
}