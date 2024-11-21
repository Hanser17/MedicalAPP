using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Base;
using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iinsurance;
using MedicalAppoiments.Persistance.Models.insuranseModel;
using MedicalAppoiments.Persistance.Repositories.usersRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection.Emit;


namespace MedicalAppoiments.Persistance.Repositories.insuranceRepository
{
    public class InsuranceProvidersRepository : BaseRepository<InsuranceProviders>, IInsuranceProvidersRepository
    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<InsuranceProvidersRepository> _logger;

        public InsuranceProvidersRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<InsuranceProvidersRepository> logger) : base(medicalAppointmentContext)
        {
            _medicalAppointmentContext = medicalAppointmentContext;
            _logger = logger;
        }

        public async override Task<OperationResult> Save(InsuranceProviders entity)
        {
            var operationResult = new OperationResult();

            if (string.IsNullOrEmpty(entity.Name) || entity.Name.Length >= 100)
            {
                operationResult.success = false;
                operationResult.message = "Nombre de seguro requerido y no puede ser mayor a 100 caracteres  ";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.ContactNumber) || !System.Text.RegularExpressions.Regex.IsMatch(entity.ContactNumber, @"^\d+$") || entity.ContactNumber.Length != 10)
            {
                operationResult.success = false;
                operationResult.message = "Número de teléfono requerido, debe contener solo dígitos y tener exactamente 10 dígitos.";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.Email) || entity.Email.Length >= 255)
            {
                operationResult.success = false;
                operationResult.message = "Email de seguro requerido y no puede ser mayor a 255 caracteres  ";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.Website) || entity.Website.Length >= 255)
            {
                operationResult.success = false;
                operationResult.message = "website de seguro requerido y no puede ser mayor a 255 caracteres  ";
                return operationResult;
            }
            if ( entity.Website.Length >= 255)
            {
                operationResult.success = false;
                operationResult.message = "website de seguro no puede ser mayor a 255 caracteres  ";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.Address) || entity.Address.Length >= 255)
            {
                operationResult.success = false;
                operationResult.message = "Address de seguro requerido y no puede ser mayor a 255 caracteres  ";
                return operationResult;
            }
            if (entity.City.Length >= 100)
            {
                operationResult.success = false;
                operationResult.message = "City de seguro no puede ser mayor a 100 caracteres  ";
                return operationResult;
            }
            if (entity.State.Length >= 100)
            {
                operationResult.success = false;
                operationResult.message = "State de seguro no puede ser mayor a 100 caracteres  ";
                return operationResult;
            }
            if (entity.Country.Length >= 100)
            {
                operationResult.success = false;
                operationResult.message = "Country de seguro no puede ser mayor a 100 caracteres  ";
                return operationResult;
            }
            if (entity.ZipCode.Length >= 10)
            {
                operationResult.success = false;
                operationResult.message = "ZipCode de seguro no puede ser mayor a 10 caracteres  ";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.CoverageDetails))
            {
                operationResult.success = false;
                operationResult.message = "CoverageDetails de seguro requerido";
                return operationResult;
            }
            if (entity.LogoUrl.Length >= 255)
            {
                operationResult.success = false;
                operationResult.message = "LogoUrl de seguro no puede ser mayor a 255 caracteres  ";
                return operationResult;
            }
            if (entity.NetworkTypeId <= 0)
            {
                operationResult.success = false;
                operationResult.message = "NetworkTypeId de seguro no valido  ";
                return operationResult;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(entity.CustomerSupportContact, @"^\d+$") || entity.CustomerSupportContact.Length != 10)
            {
                operationResult.success = false;
                operationResult.message = "Número de servicio al cliente  debe contener solo dígitos y tener exactamente 10 dígitos.";
                return operationResult;
            }
            if (entity.AcceptedRegions.Length >= 255)
            {
                operationResult.success = false;
                operationResult.message = "AcceptedRegions de seguro no puede ser mayor a 255 caracteres  ";
                return operationResult;
            }
            if(entity.MaxCoverageAmount <= 0)
            {
                operationResult.success = false;
                operationResult.message = "MaxCoverageAmount del seguro debe ser mayor a 0 ";
                return operationResult;
            }
            if (await base.Exists(insinsuranceProvider => insinsuranceProvider.Name == entity.Name))
            {
                operationResult.success = false;
                operationResult.message = "El nombre del seguro ya esta asignanado a otro seguro ";
                return operationResult;
            }
            try
            {
                operationResult = await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error guardando Datos del seguro.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async override Task<OperationResult> Update(InsuranceProviders entity)
        {
            var operationResult = new OperationResult();
            if (string.IsNullOrEmpty(entity.Name) || entity.Name.Length >= 100)
            {
                operationResult.success = false;
                operationResult.message = "Nombre de seguro requerido y no puede ser mayor a 100 caracteres  ";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.ContactNumber) || !System.Text.RegularExpressions.Regex.IsMatch(entity.ContactNumber, @"^\d+$") || entity.ContactNumber.Length != 10)
            {
                operationResult.success = false;
                operationResult.message = "Número de teléfono requerido, debe contener solo dígitos y tener exactamente 10 dígitos.";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.Email) || entity.Email.Length >= 255)
            {
                operationResult.success = false;
                operationResult.message = "Email de seguro requerido y no puede ser mayor a 255 caracteres  ";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.Website) || entity.Website.Length >= 255)
            {
                operationResult.success = false;
                operationResult.message = "website de seguro requerido y no puede ser mayor a 255 caracteres  ";
                return operationResult;
            }
            if (entity.Website.Length >= 255)
            {
                operationResult.success = false;
                operationResult.message = "website de seguro no puede ser mayor a 255 caracteres  ";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.Address) || entity.Address.Length >= 255)
            {
                operationResult.success = false;
                operationResult.message = "Address de seguro requerido y no puede ser mayor a 255 caracteres  ";
                return operationResult;
            }
            if (entity.City.Length >= 100)
            {
                operationResult.success = false;
                operationResult.message = "City de seguro no puede ser mayor a 100 caracteres  ";
                return operationResult;
            }
            if (entity.State.Length >= 100)
            {
                operationResult.success = false;
                operationResult.message = "State de seguro no puede ser mayor a 100 caracteres  ";
                return operationResult;
            }
            if (entity.Country.Length >= 100)
            {
                operationResult.success = false;
                operationResult.message = "Country de seguro no puede ser mayor a 100 caracteres  ";
                return operationResult;
            }
            if (entity.ZipCode.Length >= 10)
            {
                operationResult.success = false;
                operationResult.message = "ZipCode de seguro no puede ser mayor a 10 caracteres  ";
                return operationResult;
            }
            if (string.IsNullOrEmpty(entity.CoverageDetails))
            {
                operationResult.success = false;
                operationResult.message = "CoverageDetails de seguro requerido";
                return operationResult;
            }
            if (entity.LogoUrl.Length >= 255)
            {
                operationResult.success = false;
                operationResult.message = "LogoUrl de seguro no puede ser mayor a 255 caracteres  ";
                return operationResult;
            }
            if (entity.NetworkTypeId <= 0)
            {
                operationResult.success = false;
                operationResult.message = "NetworkTypeId de seguro no valido  ";
                return operationResult;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(entity.CustomerSupportContact, @"^\d+$") || entity.CustomerSupportContact.Length != 10)
            {
                operationResult.success = false;
                operationResult.message = "Número de servicio al cliente  debe contener solo dígitos y tener exactamente 10 dígitos.";
                return operationResult;
            }
            if (entity.AcceptedRegions.Length >= 255)
            {
                operationResult.success = false;
                operationResult.message = "AcceptedRegions de seguro no puede ser mayor a 255 caracteres  ";
                return operationResult;
            }
            if (entity.MaxCoverageAmount.HasValue && entity.MaxCoverageAmount.Value < 0)
            {
                operationResult.success = false;
                operationResult.message = "MaxCoverageAmount del seguro debe ser mayor a 0 ";
                return operationResult;
            }
            try
            {
                InsuranceProviders insuranceProvidersoUpdate = await _medicalAppointmentContext.InsuranceProviders.FindAsync(entity.InsuranceProviderID);
                if (insuranceProvidersoUpdate == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El seguro no existe";
                    return operationResult;
                }
               

                insuranceProvidersoUpdate.Name = entity.Name;
                insuranceProvidersoUpdate.ContactNumber = entity.ContactNumber;
                insuranceProvidersoUpdate.Email = entity.Email;
                insuranceProvidersoUpdate.Website = entity.Website;
                insuranceProvidersoUpdate.Address = entity.Address;
                insuranceProvidersoUpdate.City = entity.City;
                insuranceProvidersoUpdate.State = entity.State;
                insuranceProvidersoUpdate.Country = entity.Country;
                insuranceProvidersoUpdate.ZipCode = entity.ZipCode;
                insuranceProvidersoUpdate.LogoUrl = entity.LogoUrl;
                insuranceProvidersoUpdate.IsPreferred = entity.IsPreferred;
                insuranceProvidersoUpdate.NetworkTypeId = entity.NetworkTypeId;
                insuranceProvidersoUpdate.CustomerSupportContact = entity.CustomerSupportContact;
                insuranceProvidersoUpdate.AcceptedRegions = entity.AcceptedRegions;
                insuranceProvidersoUpdate.MaxCoverageAmount = entity.MaxCoverageAmount;
                insuranceProvidersoUpdate.UpdatedAt = DateTime.Now;
                insuranceProvidersoUpdate.IsActive = entity.IsActive;


                operationResult = await base.Update(insuranceProvidersoUpdate);
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error actualizando el registro.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;

        }

        public async override Task<OperationResult> Remove(InsuranceProviders entity)
        {
            var  operationResult = new OperationResult();
            if(entity.InsuranceProviderID <= 0) 
            {
                operationResult.success = false;
                operationResult.message = "El InsuranceProviderID proporcionado no es valido";
                return operationResult;
            }
            try
            {
                InsuranceProviders insuranceProviderstoRemove = await _medicalAppointmentContext.InsuranceProviders.FindAsync(entity.InsuranceProviderID);
                if (insuranceProviderstoRemove == null)
                {
                    operationResult.success = false;
                    operationResult.message = "El InsuranceProviderID no existe";
                    return operationResult;
                }
                insuranceProviderstoRemove.IsActive = false;
                insuranceProviderstoRemove.UpdatedAt = DateTime.Now;

            }
            catch (Exception ex)
            {

                operationResult.success = false;
                operationResult.message = "Error Borrando el registro.";
                _logger.LogError(operationResult.message, ex.ToString());
            }
            return operationResult;

        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                operationResult.Data = await (from i in _medicalAppointmentContext.InsuranceProviders
                                              join n in _medicalAppointmentContext.NetworkType on i.NetworkTypeId equals n.NetworkTypeId
                                              where i.IsActive
                                              select new InsuranceProvidersModel
                                              {
                                                  InsuranceProviderName = i.Name,
                                                  InsuranceProviderID = i.InsuranceProviderID,
                                                  InsuranceProviderType = n.Name,
                                                  CoverageDetails = i.CoverageDetails,
                                                  ContactNumber = i.ContactNumber,
                                                  IsPreferred = i.IsPreferred,
                                                  
                                              }).ToListAsync();

                if (operationResult.Data.Count == 0)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró registro ";
                    return operationResult;
                }
                else
                {
                    operationResult.success = true;
                }
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos la Disponibilidad del doctor.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async override Task<OperationResult> GetEntityBy(int id)
        {
            OperationResult operationResult = new OperationResult();

            if (id <= 0)
            {
                operationResult.success = false;
                operationResult.message = "Se requiere un ID válido para realizar esta operación.";
                return operationResult;
            }

            try
            {
                operationResult.Data = await (from i in _medicalAppointmentContext.InsuranceProviders
                                              join n in _medicalAppointmentContext.NetworkType on i.NetworkTypeId equals n.NetworkTypeId
                                              where i.IsActive && i.InsuranceProviderID == id
                                              select new InsuranceProvidersModel
                                              {
                                                  InsuranceProviderName = i.Name,
                                                  InsuranceProviderID = i.InsuranceProviderID,
                                                  InsuranceProviderType = n.Name,
                                                  NetworkTypeId = n.NetworkTypeId,
                                                  CoverageDetails = i.CoverageDetails,
                                                  ContactNumber = i.ContactNumber,
                                                  Email = i.Email,
                                                  Website = i.Website,
                                                  Address = i.Address,
                                                  City = i.City,
                                                  State = i.State,
                                                  Country = i.Country,
                                                  ZipCode = i.ZipCode,
                                                  LogoUrl = i.LogoUrl,
                                                  CustomerSupportContact = i.CustomerSupportContact,
                                                  AcceptedRegions = i.AcceptedRegions,
                                                  MaxCoverageAmount = i.MaxCoverageAmount,
                                                  IsPreferred = i.IsPreferred,
                                                  IsActive = i.IsActive
                                              }).FirstOrDefaultAsync();

                if (operationResult.Data == null)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró registro ";
                    return operationResult;
                }
                else
                {
                    operationResult.success = true;
                }
            }
            catch (Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos la Disponibilidad del doctor.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

        public async Task<OperationResult> GetInsuranceProvidersByNetWork(int id)
        {
            OperationResult operationResult= new OperationResult();

            if (id <= 0)
            {
                operationResult.success = false;
                operationResult.message = "Se requiere un ID válido para realizar esta operación.";
                return operationResult;
            }

            try
            {
                operationResult.Data = await (from i in _medicalAppointmentContext.InsuranceProviders
                                              join n in _medicalAppointmentContext.NetworkType on i.NetworkTypeId equals n.NetworkTypeId
                                              where i.IsActive && i.NetworkTypeId == id
                                              select new InsuranceProvidersModel
                                              {
                                                  InsuranceProviderName = i.Name,
                                                  InsuranceProviderID = i.InsuranceProviderID,
                                                  InsuranceProviderType = n.Name,
                                                  CoverageDetails = i.CoverageDetails,
                                                  ContactNumber = i.ContactNumber,
                                                  Email = i.Email,
                                                  Website = i.Website,
                                                  Address = i.Address,
                                                  City = i.City,
                                                  State = i.State,
                                                  Country = i.Country,
                                                  ZipCode = i.ZipCode,
                                                  LogoUrl = i.LogoUrl,
                                                  CustomerSupportContact = i.CustomerSupportContact,
                                                  AcceptedRegions = i.AcceptedRegions,
                                                  MaxCoverageAmount = i.MaxCoverageAmount,
                                                  IsPreferred = i.IsPreferred,
                                                  IsActive = i.IsActive
                                              }).ToListAsync();

                if (operationResult.Data.Count == 0)
                {
                    operationResult.success = false;
                    operationResult.message = "No se encontró registro ";
                    return operationResult;
                }
                else
                {
                    operationResult.success = true;
                }
            }
            catch(Exception ex)
            {
                operationResult.success = false;
                operationResult.message = "Error opteniendo todos la Disponibilidad del doctor.";
                _logger.LogError(operationResult.message, ex);
            }

            return operationResult;
        }

    }
}
