namespace ServiceLayer.Services;
public interface IVisaHolderService
{
    IQueryable<VizaHolderDto> SelectList();
    ValueTask<VizaHolderDto> SelectByIdAsync(int id);
    ValueTask<VizaHolderDto> UpdateAsync(UpdateVizaDlDto updateVizaDlDto, int? docId, int? infId);
    ValueTask<VizaHolderDto> DeleteAsync(int id, int? docId, int? infId);
}
