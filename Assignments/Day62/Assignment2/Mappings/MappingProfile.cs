using AutoMapper;
using Day62.Assignment2.Models; // Added this to find the 'Loan' class
using Day62.Assignment2.DTOs;   // This allows using 'LoanCreateDto' directly

namespace Day62.Assignment2.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LoanCreateDto, Loan>();

        CreateMap<LoanUpdateDto, Loan>();

        CreateMap<Loan, LoanReadDto>(); 
    }
}