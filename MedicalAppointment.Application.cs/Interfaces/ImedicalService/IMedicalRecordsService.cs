using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Result;


namespace MedicalAppointment.Application.Interfaces.ImedicalService
{
    public interface  IMedicalRecordsService
    {
        public Task<OperationResult> GetAllMedicalRecordsAsync();
        public Task<OperationResult> GetByIDMedicalRecordsAsync(int id);

        public Task<OperationResult> SaveMedicalRecordsAsync(MedicalRecords medicalRecords);
        public Task<OperationResult> UpdateMedicalRecordsAsync(MedicalRecords medicalRecords);

        public Task<OperationResult> DeleteMedicalRecordsAsync(MedicalRecords medicalRecords);
    }
}
