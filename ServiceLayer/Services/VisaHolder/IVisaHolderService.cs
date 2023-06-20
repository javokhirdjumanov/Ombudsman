namespace ServiceLayer.Services;
public interface IVisaHolderService
{
    ValueTask<int> CreateAsync(CreateVizaDlDto dto);
    IQueryable<VizaHolderDto> SelectList();
    ValueTask<VizaHolderDto> SelectByIdAsync(int id);
    ValueTask<VizaHolderDto> UpdateAsync(UpdateVizaDlDto dto, int? docId, int? infId);
    ValueTask<VizaHolderDto> DeleteAsync(int id, int? docId, int? infId);
}