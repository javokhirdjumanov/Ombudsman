using DomainLayer.Constants;
using DomainLayer.Entities.HL;
using ServiceLayer.Services.Documents;
using System.ComponentModel.Design;
using System.Security;

namespace ServiceLayer.Services;
public partial class DocumentService
{
    public void ValidateIfUserNotHavePermission(DocCreateDlDto cDto)
    {
        /// if the user who wants to add a document to any organization does not belong to that organization
        if (cDto.organizationId != authServices.User.Id)
        {
            throw new Exception("You have not permession that to view this user");
        }
    }
    public void ValidateIfDocumentDesignedOrNot(DocCreateDlDto cDto)
    {
        /// If the document is not designed and the project date and number are entered !!error
        if (cDto.documentStatusId != StatusIds.DESIGNED
            && cDto.normativeDocDate is not null)
        {
            throw new Exception(
                "Your document is not designed :(");
        }
        /// If the document is drafted and does not include the draft date and number !!error
        if (cDto.documentStatusId == StatusIds.DESIGNED
            && cDto.normativeDocDate is null)
        {
            throw new Exception("Your document is designed\n" +
                 "You are obliged to give the normative document " +
                 "number and the date of the document");
        }
    }
    public void ValidateIfDocumentMemorandum(DocCreateDlDto cDto)
    {
        /// If the document type is `Memorandum' and you want to create an information letter !!error
        if (cDto.normativeDocumentId == StatusIds.MEMORANDUM
            && cDto.createLetterDlDto is not null)
        {
            throw new Exception(
                "Your document type is a `Memorandum` and " +
                "it does not contain an Information Letter :(");
        }
    }
}
