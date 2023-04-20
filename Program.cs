using System;
using System.Runtime.CompilerServices;

namespace JJJ8
{
    internal class Program
    {

        struct Status
        {
            public int hp;

            public Status(int hp)
            {
                this.hp = hp;
                Console.WriteLine("생성");
            }  
        }

        // 클래스 상속
        // => 특정 클래스의 성질을 모두 물려받는 것
        // 상속 받을 클래스 명 + ': 클래스 명'


        // 기반 클래스 (부모)
        class Parent
        {
            public string name;
            public virtual void Who()
            {
                Console.WriteLine($"Parent의 Who");
            }
        }

        // 상속 클래스 (자식)
        class Child : Parent
        {
            public int age = 10;

            public override void Who()
            {
                Console.WriteLine($"Child의 Who");
            }
        }

        class Unit
        {
            public int hp;
            public void Move()
            {
                Console.WriteLine("움직임");
            }
            public virtual void Show()
            {
                Console.WriteLine(hp);
            }
        }

        class Marine : Unit
        {
            public int hp;
            public Marine(int hp)
            {
                this.hp=hp;
            }

            public void Show()
            {
                Console.WriteLine(hp);
            }
            public void Move()
            {
                Console.WriteLine("마린) 움직임");
            }
        }

        class Zealot : Unit
        {
            public int hp;
            public int shield;

            public Zealot (int hp, int shield)
            {
                this.hp= hp;
                this.shield= shield;
            }
            public override void Show()
            {
                Console.WriteLine (hp);
                Console.WriteLine (shield);
            }
            public void Move()
            {
                Console.WriteLine("질럿) 움직임");
            }
        }

        class Animal
        {
            public string name;
            public int age;

            // 가상(virtual) 함수
            // 상속 받는 클래스가 함수를 덮어써 재정의하여 오버라이딩하게 해주는 키워드
            public virtual void Eat(string food)
            {
                Console.WriteLine($"{name}이(가) {food}(을)를 먹는다.");
            }
        }
        class Lion : Animal
        {

            public Lion(int age)
            {
                name = "사자";
                this.age = age;
            }
            // 오버라이딩(override)
            // -> Eat의 내용을 변경한다.

            public override void Eat(string food)
            {
                if (food == "사료")
                {
                    Console.WriteLine("사자는 사료를 먹지 않습니다");
                }
                else
                {
                    Console.WriteLine($"{name}이(가) {food}(을)를 먹는다.");
                }
            }
        }
        class Cat : Animal
        {
            public Cat(int age)
            {
                name = "고양이";
                this.age = age;
            }
        }

        class Lifer
        {
            public virtual void Check()
            {
                Console.WriteLine("이게 되네");
            }
        }
        class Person : Lifer
        {
            // protected는 상속 관계에서는 공개하는 접근 제한자이다.

            protected int age;
            protected string name;

            public virtual void Show()
            {
                Console.WriteLine($"나의 이름은 {name}이다");
                Console.WriteLine($"나이는 {age}이다.");
            }
            public override void Check()
            {
                base.Check();
            }
        }
        class Jammin : Person
        {
            public int classNumber;
            public int attendNumber;

            public Jammin(int age, string name, int classNumber, int attendNumber)
            {
                this.age=age;
                this.name=name;
                this.classNumber=classNumber;
                this.attendNumber=attendNumber;
            }
            public override void Show()
            {
                // base
                // this와 다르게 재정의 되기 전의 기반 클래스의 요소를 우선 호출하는 키워드. 
                base.Show();
                Console.WriteLine($"출석번호는 {classNumber}번이다.");
                Console.WriteLine($"반은 {attendNumber}반이다.");
            }
            public override void Check()
            {
                base.Check();
            }
            
            
        }

        class Haksik : Person
        {
            public int studentID;
            public string department;

            public Haksik (int age, string name, int studentID, string department)
            {
                this.age=age;
                this.name=name;
                this.studentID=studentID;
                this.department=department;

            }

            public override void Show()
            {
                base.Show();
                Console.WriteLine($"학번은 {studentID}번이다.");
                Console.WriteLine($"학과는 {department}이다.");
            }
        }


        static void Main(string[] args)
        {
            // F12 / ctrl + 클릭 : 함수 식, 객체 구성 확인

            // 구조체
            // => 데이터의 구조체 (값 형 타입, 참조 타입인 클래스와 차이점)
            
            
            // 구조체는 new연산을 했다고 해서 힙 영역에 동적할당 되는 것이 아니다.
            Status stat1 = new Status(100);
            Status stat2 = stat1;
            stat2.hp = 200;
            
            Console.WriteLine(stat1.hp);
            Console.WriteLine(stat2.hp);
            // class의 얕은 복사와 같은 식이지만 서로 다른 값이 출력된다. (값 형 타입이라는 증명)

            Child child = new Child();
            child.name = "ss"; // 빈 클래스이지만 부모에게 상속 받은 요소를 가지고 있다.
            child.Who();

            Marine marine = new Marine(100);
            Zealot zealot = new Zealot(120, 50);

            marine.Move();
            zealot.Move(); // 따로 호출해야 함

            Parent parent = new Parent();
            Parent parent2 = new Child(); // Child는 Parent를 완전히 상속 받았기 때문에 참조가 가능하다.
            // Child child = new parent(); // 그 반대인 Child가 Parent를 참조하는 것은 불가능하다.

            // as, is 키워드.
            Animal[] animals = new Animal[2];
            animals[0] = new Lion(5);
            animals[1] = new Cat(2);

            for(int i = 0; i < animals.Length; i++)
            {
                animals[i].Eat("사료");
            }

            
            // is 키워드 : A 클래스가 B 클래스인가? 를 묻는 bool형 키워드
            Console.WriteLine($"animals[0]은 Cat인가? : {animals[0] is Cat}");
            Console.WriteLine($"animals[0]은 Lion인가? : {animals[0] is Lion}");

            // as 키워드 : A클래스를 B클래스로 변환하라 라는 키워드
            // 상속 클래스의 생성자는 어떻게 되는가?
            Lion lion = animals[0] as Lion; // as를 사용한 'animals -> Lion' 클래스 변환식

            if (parent2 is Child)
            {
                Child child2 = parent2 as Child;
                child2.age = 5;
            }

            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].Eat("사료");
            }

            // unit 변수는 담고있는 대상으로 Marine이 아니라 unit을 쓰고 있다.
            Unit[] unit = new Unit[2];
            unit[0]= new Marine(200);
            unit[1]= new Zealot(200,50);

            // unit.Show(); 때문에 마린 내부에만 있는 함수 사용은 불가능
            // Unit에도 같은 함수를 만들어준다.

            unit[0].Show();
            unit[1].Show();


            // Unit은 int hp, void Show(), void Move()가 있다는 사실을 알고있다.
            // 현재 내가 참조하고 있는 대상의 Show()를 호출했다.
            // 실제 참조 대상의 Show()는 내용을 오버라이드 했기 때문에 해당 내용으로 출력된다.

            // Q. 사람은 기본적으로 이름과 나이가 존재한다.
            // 초등학생과 대학생을 만들 것이다.
            // 초등학생 이름 나이 출석번호 학반
            // 대학생 이름 나이 학번 학과

            Jammin jammin = new Jammin(11, "잼민이", 22, 3);
            Haksik hakkic = new Haksik(22, "학식이", 20152222, "문창과");

            Person[] persons = new Person[2];
            persons[0] = jammin;
            persons[1] = hakkic;

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i].Show();
            }

            jammin.Check();

        }
    }
}
