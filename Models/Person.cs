namespace DotnetVulnsExamples
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            FullText = $"{name} {age}";
        }

        public string FullText {get;set;}
    }
}