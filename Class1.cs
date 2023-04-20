using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJJ8
{

    // 외부 클래스
    // 메인에 Class1.Start()로 호출하면 사용 가능
    internal class Class1
    {
        class Item
        {
            public string name;
        }
        class LifeItem : Item
        {
            public int life;
        }

        class Invertory
        {
            Item[] item;
            LifeItem[] Lifeitem;
        }

        public static void Start()
        {
            Item item1 = new Item() { name = "내구도 없는 아이템"}; // public을 사용할 경우 생성자가 없어도 값 대입 가능
            Item item2 = new LifeItem() { name = "내구도 있는 아이템", life = 100 };


            // Console.WriteLine(item1.GetType);

            // C++ 같은 경우 아웃오브렌지에서 해당 주소에 적합한 값이 있다면 값이 출력 될 수 있다.
            // 하지만 C#은 클래스로 이루어져있기에 내부 함수에서 오류 값을 내보내기에 그럴수 없다.

        }
    }
}
