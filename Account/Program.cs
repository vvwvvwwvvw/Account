using System;
using System.Collections;

namespace Account
{
    // 계정 정보
    struct slip
    {
        public int type; // 자산(1), 부채(2), 자본(3), 수익(4), 비용(5)
        public string account;
        public int amount;
    }
    class Program
    {
        // 계정금액 변동 등록
        static void AddSlip(slip[] s)
        {
            string[] names1 = { "현금", "매출채권", "미수금", "건물", "기계장치" }; // 자산
            string[] names2 = { "매입 채무", "차입금", "미지급금" }; // 부채
            string[] names3 = { "자본금", "자본 잉여금", "이익 잉여금" }; // 자본
            string[] names4 = { "매출액", "건물 입대료", "이자수익" }; // 수익
            string[] names5 = { "매출 원가", "임차료", "급여", "광고선전비" }; //비용
            Console.Write("날짜를 입력해 주세요(1~31)");
            int n = int.Parse(Console.ReadLine());
            Console.Write("계정유형을 입력하세요 자산 = 1, 부채 = 2, 자본 = 3, 수익 = 4, 비용 = 5> ");
            s[n].type = int.Parse(Console.ReadLine());
            switch (s[n].type)
            {
                case 1:
                    {
                        Console.Write("계정을 입력하세요");
                        for (int i = 0; i < names1.Length; i++)
                        {
                            Console.Write("{0} + {1}", names1[i], i + 1);
                            Console.Write(">");
                            int id = int.Parse(Console.ReadLine());
                            s[n].account = names1[i];
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("계정을 입력하세요");
                        for (int i = 0; i < names2.Length; i++)
                        {
                            Console.Write("{0} + {1}", names2[i], i + 1);
                            Console.Write(">");
                            int id = int.Parse(Console.ReadLine());
                            s[n].account = names2[i];
                        }
                        break;
                    }
                case 3:
                    {
                        Console.Write("계정을 입력하세요");
                        for (int i = 0; i < names3.Length; i++)
                        {
                            Console.Write("{0} + {1}", names3[i], i + 1);
                            Console.Write(">");
                            int id = int.Parse(Console.ReadLine());
                            s[n].account = names3[i];
                        }
                        break;
                    }
                case 4:
                    {
                        Console.Write("계정을 입력하세요");
                        for (int i = 0; i < names4.Length; i++)
                        {
                            Console.Write("{0} + {1}", names4[i], i + 1);
                            Console.Write(">");
                            int id = int.Parse(Console.ReadLine());
                            s[n].account = names4[i];
                        }
                        break;
                    }
                case 5:
                    {
                        Console.Write("계정을 입력하세요");
                        for (int i = 0; i < names5.Length; i++)
                        {
                            Console.Write("{0} + {1}", names5[i], i + 1);
                            Console.Write(">");
                            int id = int.Parse(Console.ReadLine());
                            s[n].account = names5[i];
                        }
                        break;
                    }
            }
            Console.Write("금액을 입력하세요 >");
            s[n].amount = int.Parse(Console.ReadLine());
        }
        // 계정별로 정리하여 Hashtable을 만듦
        static Hashtable AccountSummary(slip[] s, int type)
        {
            Hashtable summary =new Hashtable();
            for (int i = 0; i < 31; i++)
            {
                if (s[i].account != null && s[i].type == type)
                {
                    string key = s[i].account;
                    if (summary.ContainsKey(key))
                    {
                        summary[key] = (int)summary[key] + s[i].amount;
                    }
                    else
                    {
                        summary.Add(key, s[i].amount);
                    }
                }
            }
                return summary;
        }
        // 계정 유형별로 정리하여 출력
        static void PrintAccountSummary(slip[] s, int type, string typename)
        {
            Hashtable summary = AccountSummary(s, type); // 계정별로 정리한다
            int sum = 0;
            foreach (DictionaryEntry cs in summary)
            {
                string account = (string)cs.Key;
                int total = (int)cs.Value;
                Console.WriteLine("{0} = {1}",account, total); // 계정이름과 금액 출력
                sum = sum + total;
            }
            Console.WriteLine(" ** {0}총합 = {1}", typename, sum); // 전체 합을 출력
        }
        // 재무상태표 출력
        static void StatementFinancialPosition(slip[] s)
        {
            PrintAccountSummary(s, 1, "자산");
            PrintAccountSummary(s, 2, "부채");
            PrintAccountSummary(s, 3, "자본");
        }
        // 손익 계산서 출력
        static void StatementComprehensiveIncome(slip[] s)
        {
            PrintAccountSummary(s, 4, "수익");
            PrintAccountSummary(s, 5, "비용");

        }
        // 메뉴를 입력받아서 필요한 메소드를 호출하는 메인 메소드 정의
        static void Main(string[] args)
        {
            slip[] data = new slip[31];
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("# 1 = 전표 등록, 2 = 재무상태 표, 3 = 손익 계산서, 0 = 종료");
                Console.Write("원하는 작업을 선택 하세요 -->");
                int command = int.Parse(Console.ReadLine());
                if (command == 0)
                {
                    break;
                    Console.WriteLine();
                }switch (command)
                {
                    case 1:
                        {
                            AddSlip(data); // 전표등록 실행
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("#### 재무 상태표 ####");
                            StatementFinancialPosition(data); // 재무 상태표 출력
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("#### 손익 계산서 ####");
                            StatementComprehensiveIncome(data);
                            break;
                        }
                }
            }
        }
    }
}
