using System;

namespace Leave_Portal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Get Employee details and store it in the EmployeeDetail object

            EmployeeDetail employeeDetail = new EmployeeDetail();

            Console.WriteLine("Enter Employee Id: ");
            employeeDetail.EmployeeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name: ");
            employeeDetail.EmployeeName = Console.ReadLine();
            Console.WriteLine("Enter Employee Location: ");
            employeeDetail.EmployeeLocation = Console.ReadLine();

            // Get Leave request date

            Console.WriteLine("Enter Leave Request Date: ");
            DateTime leaveRequestDate = Convert.ToDateTime(Console.ReadLine());

            //Call CheckLeaveRequestDate method from Verification class
            
            Verification verification = new Verification();
            string leaveMessage = verification.CheckLeaveRequestDate(leaveRequestDate);

            //Display the output using object along with the message as expected
            Console.WriteLine("----------");
            Console.WriteLine("Employee Id - "+ employeeDetail.EmployeeId);
            Console.WriteLine("Name - "+ employeeDetail.EmployeeName);
            Console.WriteLine("Location - "+ employeeDetail.EmployeeLocation);
            Console.WriteLine(leaveMessage);
            Console.WriteLine("----------");
            Console.ReadLine();
        }
    }
}
