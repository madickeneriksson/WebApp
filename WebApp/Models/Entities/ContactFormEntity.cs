﻿using System.ComponentModel.DataAnnotations;
using WebApp.Models.dtos;
using WebApp.ViewModels;

namespace WebApp.Models.Entities
{
    public class ContactFormEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Company { get; set; }
        public string Message { get; set; } = null!;

        public static implicit operator ContactForm (ContactFormEntity contactFormEntity)
        {
            return new ContactForm
            {
                Id = contactFormEntity.Id,
                Name = contactFormEntity.Name,
                Email = contactFormEntity.Email,
                PhoneNumber = contactFormEntity.PhoneNumber,
                Company = contactFormEntity.Company,
                Message = contactFormEntity.Message
            };

        }

    }
}
