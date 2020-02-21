using System;
using System.Collections.Generic;
using System.IO;
using AutoMapper;
using IncidentReport.Application.Files;
using Microsoft.AspNetCore.Http;

namespace IncidentManagmentSystem.Web.Files
{
    public class IFormFileTypeConverter : ITypeConverter<List<IFormFile>, List<FileData>>
    {
        public List<FileData> Convert(List<IFormFile> source, List<FileData> destination, ResolutionContext context)
        {
            var fileDataList = new List<FileData>();
            if(source != null)
            {
                foreach (var file in source)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        fileDataList.Add(new FileData(file.FileName, memoryStream.ToArray()));
                    }
                }
            }       

            return fileDataList;
        }
    }
}
