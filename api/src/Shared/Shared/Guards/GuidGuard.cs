namespace Shared.Guards;
public static class GuidGuard
{
    public static void AgainstEmptyGuid(Guid value, string parameterName)
    {
        if (value == Guid.Empty)
            throw new ArgumentException($"{parameterName} cannot be empty.", parameterName);
    }
}
