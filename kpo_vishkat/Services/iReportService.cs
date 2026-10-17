using kpo_vishkat.Models;

namespace kpo_vishkat.Services;

public interface iReportService
{
    string Name { get; }
    string generate();
}