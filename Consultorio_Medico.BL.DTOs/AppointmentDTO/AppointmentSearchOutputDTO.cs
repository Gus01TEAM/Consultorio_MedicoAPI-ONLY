﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Medico.BL.DTOs.AppointmentDTO
{
    public class AppointmentSearchOutputDTO
    {
        [Key]
        public int AppointmentId { get; set; }
        [ForeignKey("UsersSchedules")]
        public int UserSchedulesId { get; set; }
        public string UserName { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Reason { get; set; }
        public DateTime Appointment_date { get; set; }
        public decimal Appointment_Hour { get; set; }
        public byte Status { get; set; }
        public bool? Shift { get; set; }
        // public decimal Cupo { get; set; }
        string strStatus = "";
        public String StrStatus
        {
            get
            {
                if (Status == 1)
                {
                    strStatus = "Done";
                }
                else if (Status == 2)
                {
                    strStatus = "Inactive";
                }
                else if (Status == 3)
                {
                    strStatus = "Pending";
                }
                else
                {
                    strStatus = "Canceled";
                }

                return strStatus;
            }
        }
        string strStatus2 = "";
        public String StrStatus2
        {
            get
            {
                if (Shift == true)
                {
                    strStatus = "AM";
                }
                else
                {
                    strStatus = "PM";
                }
                return strStatus;
            }
        }
    }
    public enum Appointment_Status
    {
        Done = 1,
        Inactive = 2,
        Pending = 3,
        Canceled = 4,
    }
 
    public enum Appointment_Shift
    {
        AM = 1,
        PM = 2,
    }

}
