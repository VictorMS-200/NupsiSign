using NupsiSign.Models.DbSet;

namespace NupsiSign.Services;

public class QuestionService
{
    private List<Question> list = new()
    {
        new Question("The marriage will be celebrated",
            new List<string>
            {
                "At the Registry Office",
                "Outside the Registry Office with our Justice of the Peace (e.g., Residence, Farm, Restaurants, others)",
                "Religious with civil effect with Pastor", "Conversion of Stable Union into Marriage",
                "I will qualify to marry at another Registry Office"
            }),
        new Question("Property Regime adopted by the couple",
            new List<string>
            {
                "Partial Community of Property",
                "Universal Community of Property (requires Prenuptial Agreement done at the Notary's Office)",
                "Separation of Property (requires Prenuptial Agreement done at the Notary's Office)",
                "Final Participation of Acquests (requires Prenuptial Agreement done at the Notary's Office)",
                "MANDATORY Separation of Property: This regime DOES NOT require a prenuptial agreement and MUST be used in cases where the couple is over 70 years of age OR are DIVORCED/WIDOWED and cannot prove the division of assets/inventory from the previous marriage."
            }),
        new Question("Groom's Full Name"),
        new Question("Name to be used after the Marriage"),
        new Question("Groom's Marital Status",
            new List<string>
            {
                "Single",
                "Divorced",
                "Widower"
            }),
        new Question("Groom's Phone (Enter NUMBERS ONLY to work.)"),
        new Question("Groom's Profession"),
        new Question("Groom's Email"),
        new Question("Groom's Father's Full Name"),
        new Question("Groom's Father's Date of Birth", true),
        new Question("Groom's Mother's Full Name"),
        new Question("Groom's Mother's Date of Birth", true),
        new Question("Bride's Full Name"),
        new Question("Name to be used after the Marriage"),
        new Question("Bride's Marital Status",
            new List<string>
            {
                "Single",
                "Divorced",
                "Widow"
            }),
        new Question("Bride's Phone (Enter NUMBERS ONLY to work.)"),
        new Question("Bride's Profession"),
        new Question("Bride's Email"),
        new Question("Bride's Father's Full Name"),
        new Question("Bride's Father's Date of Birth", true),
        new Question("Bride's Mother's Full Name"),
        new Question("Bride's Mother's Date of Birth", true),
        new Question("Full Name of the 1st Witness"),
        new Question("Marital Status of the 1st Witness",
            new List<string>
            {
                "Single",
                "Divorced",
                "Widowed",
                "Married"
            }),
        new Question("Profession of the 1st Witness"),
        new Question("Date of Birth of the 1st Witness", true),
        new Question("ID Document and issuing authority of the 1st Witness"),
        new Question("CPF of the 1st Witness"),
        new Question("Full Address of the 1st Witness"),
        new Question("Full Name of the 2nd Witness"),
        new Question("Marital Status of the 2nd Witness",
            new List<string>
            {
                "Single",
                "Divorced",
                "Widowed",
                "Married"
            }),
        new Question("Profession of the 2nd Witness"),
        new Question("Date of Birth of the 2nd Witness", true),
        new Question("ID Document and issuing authority of the 2nd Witness"),
        new Question("CPF of the 2nd Witness"),
        new Question("Full Address of the 2nd Witness")
    };
    public async Task<List<Question>> GetQuestions()
    {
        return await Task.FromResult(list);
    }
};