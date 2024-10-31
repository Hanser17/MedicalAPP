using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;


namespace MedicalAppointment.Application.Interfaces.ImedicalService
{
    public interface  IMedicalRecordsService
    {
         Task<OperationResult> GetAllMedicalRecordsAsync();
         Task<OperationResult> GetByIDMedicalRecordsAsync(int id);

         Task<OperationResult> SaveMedicalRecordsAsync(MedicalRecords medicalRecords);
         Task<OperationResult> UpdateMedicalRecordsAsync(MedicalRecords medicalRecords);

         Task<OperationResult> DeleteMedicalRecordsAsync(MedicalRecords medicalRecords);
    }
}
