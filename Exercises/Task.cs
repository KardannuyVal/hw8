using System;
using System.Collections.Generic;
using System.Linq;


namespace Exercises
{
    enum ReportFrequency
    {
        Daily,
        Weekly,
        Monthly
    }
    enum TaskStatus
    {
        Appointed,
        InProgress,
        Test,
        Completed
    }
    internal class Task
    {
        private string description { get; set; }
        private DateTime deadline { get; set; }
        private Person customer { get; set; }
        private Person executor { get; set; }
        private TaskStatus status;
        public TaskStatus Status 
        { 
            get 
            { 
                return status; 
            } 
        }

        public ReportFrequency report_frequency { get; set; }
        private List<Report> reports { get; set; }
        public Task(string description, DateTime deadline, Person customer, ReportFrequency report_frequency)
        {
            this.description = description;
            this.deadline = deadline;
            this.customer = customer;
            status = TaskStatus.Appointed;
            reports = new List<Report>();
            this.report_frequency = report_frequency;
        }
        /// <summary>
        /// Меняет статус на начавшийся
        /// </summary>
        /// <param name="executor"></param>
        public void StartTask(Person executor)
        {
            status = TaskStatus.InProgress;
            this.executor = executor;
        }
        /// <summary>
        /// Меняет статус на тестируемый
        /// </summary>
        public void TestTask() 
        {
            status = TaskStatus.Test;
        }
        /// <summary>
        /// Меняет статус на закончившийся
        /// </summary>
        public void ClosedTask()
        {
            status = TaskStatus.Completed;
        }
        /// <summary>
        /// Добавляет отчет в список
        /// </summary>
        /// <param name="report"></param>
        public void AddReport(Report report)
        {
            reports.Add(report);
        }
        /// <summary>
        /// Передает задание другому
        /// </summary>
        /// <param name="executor"></param>
        public void DelegateTask(Person executor)
        {
            if (status == TaskStatus.Appointed)
            {
                this.executor = executor;
            }
        }
        /// <summary>
        /// Отказывется от задания
        /// </summary>
        public void RejectTask()
        {
            executor = null;
            status = TaskStatus.Appointed;
        }

        /// <summary>
        /// Генерирует переодичные отчеты
        /// </summary>
        public void GenerateReports()
        {
            TestTask();
            if (status == TaskStatus.InProgress)
            {
                DateTime today = DateTime.Today;

                if (report_frequency == ReportFrequency.Daily)
                {
                    if (!reports.Any(report => report.Time == today))
                    {
                        Report daily_report = new Report("Дневной отчет", executor);
                        AddReport(daily_report);
                        if (daily_report.Approve())
                        {
                            ClosedTask();
                            Console.WriteLine("Отчет принят\n");
                        }
                        else
                        {
                            StartTask(executor);
                            Console.WriteLine("Отчет не принят, на доработку\n");
                        }
                    }
                }
                else if (report_frequency == ReportFrequency.Weekly)
                {
                    if (today.DayOfWeek == DayOfWeek.Monday && !reports.Any(report => report.Time.Date >= today.AddDays(-7)))
                    {
                        Report monthly_report = new Report("Недельный отчет", executor);
                        AddReport(monthly_report);
                        if (monthly_report.Approve())
                        {
                            ClosedTask();
                            Console.WriteLine("Отчет принят\n");

                        }
                        else
                        {
                            StartTask(executor);
                            Console.WriteLine("Отчет не принят, на доработку\n");
                        }
                    }
                }
                else if (report_frequency == ReportFrequency.Monthly)
                {
                    if (today.Day == 1 && !reports.Any(report => report.Time.Date >= today.AddMonths(-1)))
                    {
                       Report monthly_report = new Report("Месячный отчёт", executor);
                       AddReport(monthly_report);
                       if (monthly_report.Approve())
                       {
                           ClosedTask();
                           Console.WriteLine("Отчет принят\n");
                       }
                       else
                       {
                           StartTask(executor);
                           Console.WriteLine("Отчет не принят, на доработку\n");
                       }
                    }
                }
            }
        }
    }
}
