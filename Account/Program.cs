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
        }
        // 계정 유형별로 정리하여 출력
        static void PrintAccountSummary(slip[] s, int type, string typename)
        {
        
        }
        // 재무상태표 출력
        static void StatementFinancialPosition(slip[] s)
        {
        
        }
        // 손익 계산서 출력
        static void StatementComprehensiveIncome(slip[] s)
        {

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
