using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace xmllinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //task 14:
            XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", null),
                new XElement("RootTag",
                    new XElement("Child1","TextValue1"),
                    new XElement("Child2", "TextValue2"),
                    new XElement("Child3",
                        new XElement("InnerChild3","InnerTextValue3")
                    ),
                    new XElement("Child4", "TextValue3")
                )
            );

            var resp14 = xdoc.Root.Elements().Nodes().OfType<XText>();

            Console.WriteLine("LinqXML14: Дан  XML-документ.  Найти  элементы  второго уровня, имеющие дочерний текстовый узел, " +
                "и вывести коли-чество найденных элементов, а также имя каждого найден-ного элемента и значение его дочернего текстового узла. " +
                "По-рядок вывода элементов должен соответствовать порядку их следования в документе.");
            Console.WriteLine("\nТестируемый XML:");
            Console.WriteLine(xdoc);
            Console.WriteLine("\nОтвет:");
            foreach (var r in resp14)
            {
                Console.WriteLine(r);
            }


            //task 30:
            Console.WriteLine("\n\nLinqXML30: Дан  XML-документ.  Удалить  из  документа  все элементы  третьего  уровня,  представленные  комбинирован-ным тегом. Указание. " +
                "Использовать свойство IsEmpty класса XElement.");

            XDocument xdoc30 = new XDocument(new XDeclaration("1.0", "UTF-8", null),
                new XElement("RootTag",
                    new XElement("Child1", "TextValue1"),
                    new XElement("Child2",
                        new XElement("InnerChild2",
                            new XAttribute("someAtr2", "someAtrValue2")
                    )),
                    new XElement("Child3",
                        new XElement("InnerChild2",
                            new XElement("InnerInnerChild2", "InnerTextValue2")
                    )),
                    new XElement("Child4",
                        new XElement("InnerChild4",
                            new XAttribute("someAtr4", "someAtrValue4")
                    )),
                    new XElement("Child5",
                        new XElement("InnerChild2",
                            new XElement("InnerInnerChild2", "InnerTextValue2")
                    )),
                    new XElement("Child4", "TextValue3")
                    )
                );
            Console.WriteLine("\nТестируемый XML:");
            Console.WriteLine(xdoc30);

            xdoc30.Root.Elements().Elements().Where(n => n.IsEmpty).Remove();
            Console.WriteLine("\nОтвет:");
            Console.WriteLine(xdoc30);

            //task 30:
            Console.WriteLine("\n\nДан  XML-документ.  Для  каждого  элемента, имеющего дочерние элементы, добавить в конец его набора атрибутов атрибут с именем " +
                "odd-node-count и логическим значением, равным true, если суммарное количество дочер-них узлов у всех его дочерних элементов является нечетным, и false" +
                " в противном случае");

            XDocument xdoc46 = new XDocument(new XDeclaration("1.0", "UTF-8", null),
                new XElement("RootTag",
                    new XElement("Child1", "TextValue1"),
                    new XElement("Child2",
                        new XElement("InnerChild2",
                            new XAttribute("someAtr2", "someAtrValue2")
                    )),
                    new XElement("Child3",
                        new XElement("InnerChild2",
                            new XElement("InnerInnerChild2", "InnerTextValue2")
                    )),
                    new XElement("Child4",
                        new XElement("InnerChild4",
                            new XElement("InnerInnerChild4-1", "InnerTextValue4-1"),
                            new XElement("InnerInnerChild4-2", "InnerTextValue4-2"),
                            new XElement("InnerInnerChild4-3", "InnerTextValue4-3"),
                            new XElement("InnerInnerChild4-4", "InnerTextValue4-4")
                    )),
                    new XElement("Child5",
                        new XElement("InnerChild5",
                            new XElement("InnerInnerChild5-1",
                                new XElement("InnerInnerChild5-1-1", "InnerTextValue5-1-1"),
                                new XElement("InnerInnerChild5-1-2", "InnerTextValue5-1-2")),
                            new XElement("InnerInnerChild5-2", "InnerTextValue5-2")

                    )),
                    new XElement("Child4", "TextValue3")
                    )
                );
            Console.WriteLine("\nТестируемый XML:");
            Console.WriteLine(xdoc46);

            xdoc46.Descendants().Where(n => n.Elements().Count() > 0).ToList().ForEach(e=>attributeAdder(e));

            Console.WriteLine("\nОтвет:");
            Console.WriteLine(xdoc46);



            Console.ReadLine();
        }

        public static XElement attributeAdder(XElement element)
        {
            bool isOdd = element.Nodes().Count() % 2 == 0 ? false : true;
            element.Add(new XAttribute("odd-node-count", isOdd));
            return element;
        }
    }
}
