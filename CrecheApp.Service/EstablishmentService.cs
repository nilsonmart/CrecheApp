using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Interface.Repository;
using CrecheApp.Domain.Interface.Service;
using CrecheApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrecheApp.Service
{
    public class EstablishmentService : IEstablishmentService
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public EstablishmentService(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }
        public void Add(EstablishmentModel entity)
        {
            var retval = ConvertToEntity(entity);
            retval.GlobalId = Guid.NewGuid();
            retval.CreationUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            retval.CreationDate = DateTime.UtcNow;
            _establishmentRepository.Add(retval);
        }

        public void Delete(Guid globalId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstablishmentModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public EstablishmentModel GetByGlobalId(Guid globalId)
        {
            throw new NotImplementedException();
        }

        public EstablishmentModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EstablishmentModel entity)
        {
            throw new NotImplementedException();
        }

        private Account ConvertToEntity(AccountModel model)
        {
            return new Account
            {
                Id = model.Id,
                GlobalId = model.GlobalId,
                Name = model.Name,
                IsActive = model.IsActive,
                CreationUser = model.CreationUser,
                CreationDate = model.CreationDate,
                LastChangeUser = model.LastChangeUser,
                LastChangeDate = model.LastChangeDate,
            };
        }

        private EstablishmentModel ConvertToDomain(Establishment entity)
        {
            var model = new EstablishmentModel();
            model.Id = entity.Id;
            model.GlobalId = entity.GlobalId;
            model.AccountId = entity.AccountId;
            model.Name = entity.Name;
            model.Email = entity.Email;
            model.Phone = entity.Phone;
            model.PhoneBranchLine = entity.PhoneBranchLine;
            if (entity.Address != null)
            {
                model.Address = new AddressModel
                {
                    Id = entity.Address.Id,
                    GlobalId = entity.Address.GlobalId,
                    ZipCode = entity.Address.ZipCode,
                    City = entity.Address.City,
                    Complement = entity.Address.Complement,
                    Country = entity.Address.Country,
                    CreationDate = entity.Address.CreationDate,
                    CreationUser = entity.Address.CreationUser,
                    LastChangeDate = entity.Address.LastChangeDate,
                    LastChangeUser = entity.Address.LastChangeUser,
                    Number = entity.Address.Number,
                    Street = entity.Address.Street
                };
            };

            if (entity.Staffs != null)
            {
                var staffList = new List<StaffModel>();
                foreach (var staff in entity.Staffs)
                {
                    var staffModel = new StaffModel();
                    staffModel.Id = staff.Id;
                    staffModel.GlobalId = staff.GlobalId;
                    staffModel.AccountId = staff.AccountId;
                    staffModel.FirstName = staff.FirstName;
                    staffModel.LastName = staff.LastName;
                    staffModel.Email = staff.Email;
                    staffModel.FiscalNumber = staff.FiscalNumber;
                    staffModel.IDNumber = staff.IDNumber;
                    staffModel.IsActive = staff.IsActive;
                    staffModel.MobilePhone = staff.MobilePhone;
                    staffModel.PhoneNumber = staff.PhoneNumber;
                    staffModel.UserId = staff.UserId;
                    staffModel.UserRole = staff.UserRole;
                    model.CreationUser = staff.CreationUser;
                    model.CreationDate = staff.CreationDate;
                    model.LastChangeUser = staff.LastChangeUser;
                    model.LastChangeDate = staff.LastChangeDate;

                    if (staff.Addresses.Any())
                    {
                        var addressesModel = new List<AddressModel>();
                        foreach (var address in staff.Addresses)
                        {
                            var addressModel = new AddressModel
                            {
                                Id = address.Id,
                                City = address.City,
                                Complement = address.Complement,
                                Country = address.Country,
                                CreationDate = address.CreationDate,
                                CreationUser = address.CreationUser,
                                GlobalId = address.GlobalId,
                                LastChangeDate = address.LastChangeDate,
                                LastChangeUser = address.LastChangeUser,
                                Number = address.Number,
                                Street = address.Street,
                                ZipCode = address.ZipCode
                            };
                            addressesModel.Add(addressModel);
                        }
                        staffModel.Addresses = addressesModel;
                    }
                    staffList.Add(staffModel);
                }
                model.Staffs = staffList;
            }

            if (entity.Notes != null)
            {
                var noteList = new List<NoteModel>();
                foreach (var note in entity.Notes)
                {
                    var noteModel = new NoteModel();
                    noteModel.Id = note.Id;
                    noteModel.GloblalId = note.GloblalId;
                    noteModel.AccountId = note.AccountId;
                    noteModel.NoteName = note.NoteName;
                    noteModel.NoteValue = note.NoteValue;
                    noteModel.NoteType = note.NoteType;
                    noteModel.CreationDate = note.CreationDate;
                    noteModel.CreationUser = note.CreationUser;
                    noteModel.LastChangeDate = note.LastChangeDate;
                    noteModel.LastChangeUser = note.LastChangeUser;
                    noteList.Add(noteModel);
                }
                model.Notes = noteList;
            }

            if (entity.ClassRooms != null)
            {
                var classRoomList = new List<ClassRoomModel>();
                foreach (var classRoom in entity.ClassRooms)
                {
                    var classRoomModel = new ClassRoomModel();
                    classRoomModel.Id = classRoom.Id;
                    classRoomModel.GlobalId = classRoom.GlobalId;
                    classRoomModel.AccountId = classRoom.AccountId;
                    classRoomModel.ClassAverageEvaluation = classRoom.ClassAverageEvaluation;
                    classRoomModel.ClassEvaluation = classRoom.ClassEvaluation;
                    classRoomModel.ClassRoomCode = classRoom.ClassRoomCode;
                    classRoomModel.ClassRoomName = classRoom.ClassRoomName;
                    classRoomModel.CreationDate = classRoom.CreationDate;
                    classRoomModel.CreationUser = classRoom.CreationUser;
                    classRoomModel.EndDate = classRoom.EndDate;
                    classRoomModel.EndSummerVacation = classRoom.EndSummerVacation;
                    classRoomModel.EndWinterVacation = classRoom.EndWinterVacation;
                    classRoomModel.Files = classRoom.Files;
                    classRoomModel.LastChangeDate = classRoom.LastChangeDate;
                    classRoomModel.LastChangeUser = classRoom.LastChangeUser;
                    if (classRoom.Pupils != null)
                    {
                        var pupilsList = new List<PupilModel>();
                        foreach (var pupil in classRoom.Pupils)
                        {
                            var pupilModel = new PupilModel();
                            pupilModel.Id = pupil.Id;
                            pupilModel.GlobalId = pupil.GlobalId;
                            pupilModel.AccountId = pupil.AccountId;
                            pupilModel.Age = pupil.Age;
                        }
                    }
                }
            }

            model.CreationUser = entity.CreationUser;
            model.CreationDate = entity.CreationDate;
            model.LastChangeUser = entity.LastChangeUser;
            model.LastChangeDate = entity.LastChangeDate;

            return model;
        }
    }
}
