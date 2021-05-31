using System;
using AutoMapper;

namespace ContactApp.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }


        private static readonly MapperConfiguration
            config = new MapperConfiguration(cfg => cfg.CreateMap<ContactRepository.ContactModel, ContactModel>()
            .ReverseMap());
        private static IMapper mapper = config.CreateMapper();

        public ContactRepository.ContactModel ToRepositoryModel()
        {
            #region hide
            //var repositoryModel = new ContactRepository.ContactModel
            //{
            //    Age = Age,
            //    CreatedDate = CreatedDate,
            //    Email = Email,
            //    Id = Id,
            //    Name = Name,
            //    Notes = Notes,
            //    PhoneNumber = PhoneNumber,
            //    PhoneType = PhoneType
            //};
            #endregion

            var repositoryModel = mapper.Map<ContactRepository.ContactModel>(this);

            return repositoryModel;
        }

        public static ContactModel ToModel(ContactRepository.ContactModel repositoryModel)
        {
            #region hide
            //var contactModel = new ContactModel
            //{
            //    Age = respositoryModel.Age,
            //    CreatedDate = respositoryModel.CreatedDate,
            //    Email = respositoryModel.Email,
            //    Id = respositoryModel.Id,
            //    Name = respositoryModel.Name,
            //    Notes = respositoryModel.Notes,
            //    PhoneNumber = respositoryModel.PhoneNumber,
            //    PhoneType = respositoryModel.PhoneType
            //};
            #endregion

            var contactModel = mapper.Map<ContactModel>(repositoryModel);

            return contactModel;
        } 
        
        public ContactModel Clone()
        {
            return (ContactModel)this.MemberwiseClone();
        }
    }
}