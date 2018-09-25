using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace xworks.taskprocess
{
    class TaskFile
    {
        public static List<Task> Tasks { get; set; }

        public List<Task> LoadTasks(string filePath)
        {
            Tasks = new List<Task>();
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);  //加载Xml文件 
            XmlElement rootElem = doc.DocumentElement;  //获取根节点
            XmlNodeList RowpersonNodes = rootElem.GetElementsByTagName("task");
            foreach (XmlElement node in RowpersonNodes)
            {
                Task task = new Task();
                task.Id = Guid.Parse(node.Attributes["id"].Value);
                task.Author = node.SelectSingleNode("Author").InnerText;
                task.SubmitTime = DateTime.ParseExact(node.SelectSingleNode("SubmitTime").InnerText, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                task.Priority = (TaskPriority)Enum.Parse(typeof(TaskPriority), node.SelectSingleNode("Priority").InnerText);
                task.DueTime = DateTime.ParseExact(node.SelectSingleNode("DueTime").InnerText, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                task.Assignee = node.SelectSingleNode("Assignee").InnerText;
                task.Content = node.SelectSingleNode("Content").InnerText;
                task.HandlingNote = node.SelectSingleNode("HandlingNote").InnerText;
                task.Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), node.SelectSingleNode("Status").InnerText);
                task.Checker = node.SelectSingleNode("Checker").InnerText;
                task.CheckTime = DateTime.ParseExact(node.SelectSingleNode("CheckTime").InnerText, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                Tasks.Add(task);

            }
            return Tasks;
        }

        public void addTask(string dateTimePicker1, string textBox2, string textBox1)
        {
            TaskPriority priority = (TaskPriority)Enum.Parse(typeof(TaskPriority), "Normal");
            Task task = new Task
            {
                Id = Guid.NewGuid(),
                Author = "XXX",
                SubmitTime = DateTime.ParseExact(DateTime.Now.ToString("yyyyMMddHHmmss"), "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture),
                Priority = priority,
                DueTime = DateTime.ParseExact(dateTimePicker1, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture),
                Assignee = textBox2,
                Content = textBox1,
                HandlingNote = "",
                Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), "0"),
                Checker = "",
                CheckTime = DateTime.ParseExact("19000101000000", "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture),

            };
            Tasks.Add(task);
        }
    }
}
