using System;

public class Test
{
    public static void Main(string[] args)
    {
        int N, M, P, Q; //初期条件
        point[] points = new point[4];  //点の座標などを格納するクラス(point)を４点
        line L1, L2;    //線の端点などを格納するクラス(line)を２本
        float determinant, s, t, x, y;
        bool isPoint = false;

        while(true){
            Console.WriteLine("Please input the values in the order of N, M, P, Q.");   //値の入力を促す文を出力
            var conditions = Console.ReadLine().Split(' '); //入力をスペース区切りで配列として格納

            //入力された値の数が4、かつ全ての値が数値に変換できるかどうかチェック（TryParse時に、二つ目の引数に変換後の値を代入）
            if(conditions.Length == 4 && int.TryParse(conditions[0], out N) && int.TryParse(conditions[1], out M)
                && int.TryParse(conditions[2], out P) && int.TryParse(conditions[3], out Q)){
                break;
            }
        };

        Console.WriteLine("Please input the " + N.ToString() + " cordinates.");

        //Nの値（pointの数）分、座標を入力させる。
        for(int i = 0;i < N;i++)
        {
            while(true){
                var cordinates = Console.ReadLine().Split(' ');
                int x_temp, y_temp;
                
                //入力された値の数が2、かつ全ての値が数値に変換できるかどうかチェック
                if(cordinates.Length == 2 && int.TryParse(cordinates[0], out x_temp) && int.TryParse(cordinates[1], out y_temp)){
                    points[i] = new point(x_temp, y_temp);
                    break;
                }
                else{
                    Console.WriteLine("Please input two values as x and y cordinates.");
                }
            };
        }

        Console.WriteLine("Please choose endpoints of L1 from 1 through " + N.ToString() + ".");

        while(true){
            int p, q;
            var order = Console.ReadLine().Split(' ');

            if(order.Length == 2 && int.TryParse(order[0], out p) && int.TryParse(order[1], out q)){
                L1 = new line(points[p - 1], points[q - 1]);
                break;
            }
            else{
                Console.WriteLine("Please input two values as endpoints.");
            }
        };
        
        while(true){
            int p, q;
            var order = Console.ReadLine().Split(' ');

            if(order.Length == 2 && int.TryParse(order[0], out p) && int.TryParse(order[1], out q)){
                L2 = new line(points[p - 1], points[q - 1]);
                break;
            }
            else{
                Console.WriteLine("Please input two values as endpoints.");
            }
        };

        //行列式の計算
        determinant = (L1.q.x - L1.p.x) * (L2.p.y - L2.q.y) + (L2.q.x - L2.p.x) * (L1.q.y - L1.p.y);

        //浮動小数点型用の==0チェック
        if(-1e-7 <= determinant && 1e-7 > determinant)
        {
            Console.WriteLine("NA");
        }
        else
        {
            s = (1 / determinant) * ((L2.p.y - L2.q.y) * (L2.p.x - L1.p.x) 
                + (L2.q.x - L2.p.x) * (L2.p.y - L1.p.y));

            t = (1 / determinant) * ((L1.p.y - L1.q.y) * (L2.p.x - L1.p.x) 
                + (L1.q.x - L1.p.x) * (L2.p.y - L1.p.y));

            if((0 <= s && 1 >= s) && (0 <= t && 1 >= t))
            {
                x = L1.p.x + (L1.q.x - L1.p.x) * s;
                y = L1.p.y + (L1.q.y - L1.p.y) * s;

                foreach (var e in points)
                {
                    if(e.x == x && e.y == y)
                    {
                        isPoint = true;
                    }
                }

                //交点が端点上かチェック。
                if(isPoint){
                    Console.WriteLine("NA");
                }
                else
                {
                    //小数点以下5桁（足りない場合は0埋め）に出力をフォーマット
                    Console.WriteLine(string.Format("{0:0.00000}", x) + " " + string.Format("{0:0.00000}", y));
                }
            }
            else
            {
                Console.WriteLine("NA");
            }
        }
    }
}

