﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Application.ViewModels.TransactionViewModel
{
    public class DepositeAmount
    {
        [Required]
        public int Amount { get; set; }
    }
}
