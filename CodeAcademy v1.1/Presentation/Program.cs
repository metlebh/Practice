using Core.Constant;
using Core.Helpers;
using Core1.Entities;
using Data.Repostories.Concret;
using System;
using System.Globalization;

namespace Presentation
{

    class Program
    {
        

         static void Main(string[] args)
             
        {
            Grouprepositery _groupRepositery = new Grouprepositery();
            ConsoleHelper.WriteWithColor("****Welcome CodeAcademy****", ConsoleColor.Cyan);

            while (true)
            {

                ConsoleHelper.WriteWithColor("1-Creat Group", ConsoleColor.DarkYellow);
                ConsoleHelper.WriteWithColor("2-Update Group", ConsoleColor.DarkYellow);
                ConsoleHelper.WriteWithColor("3-Delete Group", ConsoleColor.DarkYellow);
                ConsoleHelper.WriteWithColor("4-Get All Groups", ConsoleColor.DarkYellow);
                ConsoleHelper.WriteWithColor("5-Get Group By İd", ConsoleColor.DarkYellow);
                ConsoleHelper.WriteWithColor("6-Get Group By Name", ConsoleColor.DarkYellow);
                ConsoleHelper.WriteWithColor("0-Exit", ConsoleColor.DarkYellow);

                int number;
                ConsoleHelper.WriteWithColor("**** Select Option****", ConsoleColor.Cyan);

                bool isSucceeded = int.TryParse(Console.ReadLine(), out number);
                if (!isSucceeded)
                {
                    ConsoleHelper.WriteWithColor("The entered number is not in the correct format ", ConsoleColor.DarkRed);
                }
                else
                {
                    if (!(number>=0 && number<=6))
                    {
                        ConsoleHelper.WriteWithColor("The entered number is not available\nEnter 0-6 digits", ConsoleColor.DarkRed);
                    }
                    else
                    {

                    switch (number)
                    {
                        case (int)Group_options.CreatGroup:
                             ConsoleHelper.WriteWithColor("****Enter Group Name****", ConsoleColor.DarkCyan);
                                string name = Console.ReadLine();

                                int maxSize;
                                MaxSizeDes: ConsoleHelper.WriteWithColor("****Enter Group Maxsize****", ConsoleColor.DarkCyan);
                                isSucceeded = int.TryParse(Console.ReadLine(), out maxSize);
                                if (!isSucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("Max number is not in correct format", ConsoleColor.DarkRed);
                                    goto MaxSizeDes;
                                }
                                else
                                {
                                    Console.WriteLine(maxSize);
                                }
                                if (maxSize>18)
                                {
                                    ConsoleHelper.WriteWithColor("max number cannot be greater than 18", ConsoleColor.DarkRed);
                                    goto MaxSizeDes;
                                }
                                 
                                DateTimeDes: ConsoleHelper.WriteWithColor("****Enter Start Date****", ConsoleColor.DarkCyan);
                                DateTime startDate;
                                isSucceeded = DateTime.TryParseExact(Console.ReadLine(), "dd.mm.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
                                if (!(isSucceeded))
                                {
                                    ConsoleHelper.WriteWithColor("*Start Date is not correct format\n*Example:dd.mm.yyyy", ConsoleColor.DarkRed);
                                    goto DateTimeDes;
                                }
                                DateTime boundryDate = new DateTime(2015, 1, 1);
                                if (startDate<boundryDate)
                                {
                                    ConsoleHelper.WriteWithColor("*Start date is not choosen right\n*Startig 01.01.2015", ConsoleColor.DarkRed);
                                    goto DateTimeDes;
                                }

                                EndDateTimeDes: ConsoleHelper.WriteWithColor("****Enter End Date****", ConsoleColor.DarkCyan);
                                DateTime endDate;
                                isSucceeded = DateTime.TryParseExact(Console.ReadLine(), "dd.mm.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);
                                if (!(isSucceeded))
                                {
                                    ConsoleHelper.WriteWithColor("*End Date is not correct format\n*Example:dd.mm.yyyy", ConsoleColor.DarkRed);
                                    goto EndDateTimeDes;
                                }
                                if (endDate<startDate)
                                {
                                    ConsoleHelper.WriteWithColor("The end date cannot be greater than the start date", ConsoleColor.DarkRed);
                                    goto EndDateTimeDes;
                                }

                                var group = new Group
                                {
                                    Name = name,
                                    MaxSize=maxSize,
                                    StartDate=startDate,
                                    EndDate=endDate,
                                };

                                _groupRepositery.Add(group);
                                ConsoleHelper.WriteWithColor($"Group succesfuly created\nName: {group.Name}\nMaxSize: {group.MaxSize}\nStart Date: {group.StartDate.ToShortDateString()}\nEnd Date: {group.EndDate.ToShortDateString()}", ConsoleColor.DarkMagenta);
                                                           
                                
                                break;
                        case (int)Group_options.UpdateGroup:
                            break;
                        case (int)Group_options.DeleteGroup:
                                var groupss = _groupRepositery.GetAll();
                                foreach (var groupss_ in groupss)
                                {
                                    ConsoleHelper.WriteWithColor($"Id: {groupss_.Id}\nName: {groupss_.Name}\nMax Size: {groupss_.MaxSize}\nStart Date: {groupss_.StartDate}\nEnd Date: {groupss_.EndDate}", ConsoleColor.DarkMagenta);
                                }
                                IdDes: ConsoleHelper.WriteWithColor("****ENTER ID****", ConsoleColor.DarkCyan);
                                int id;
                                isSucceeded = int.TryParse(Console.ReadLine(), out id);
                                if (!isSucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("ID is not correct variant", ConsoleColor.DarkCyan);
                                    goto IdDes;
                                }
                                var dbGroup = _groupRepositery.Get(id);
                                if (dbGroup is null)
                                {
                                    ConsoleHelper.WriteWithColor("There is no any group this iD", ConsoleColor.DarkRed);
                                }
                                else
                                {
                                    _groupRepositery.Delete(dbGroup);
                                    ConsoleHelper.WriteWithColor("Group succesfuly deleted", ConsoleColor.DarkGreen);
                                }
                                break;
                        case (int)Group_options.GetAllGroups:

                                ConsoleHelper.WriteWithColor("**** ALL GROUPS****", ConsoleColor.DarkCyan);
                                var groups = _groupRepositery.GetAll();
                                foreach (var groups_ in groups)
                                {
                                    ConsoleHelper.WriteWithColor($"Id: {groups_.Id}Name: {groups_.Name}\nMax Size: {groups_.MaxSize}\nStart Date: {groups_.StartDate}\nEnd Date: {groups_.EndDate}",ConsoleColor.DarkMagenta);
                                }
                            break;
                        case (int)Group_options.GetGroupById:
                            break;
                        case (int)Group_options.GetGroupByName:
                            break;
                        case (int)Group_options.Exit:
                                return;
                            break;

                        default:
                            break;
                    }
                    }
                }
            }






        }
    }
}
