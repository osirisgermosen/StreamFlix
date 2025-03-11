using System;
using Microsoft.Data.SqlClient;

namespace MovieMvcProject.Helpers;

public static class SqlValidate
{
    public static string GetString(SqlDataReader reader, string columnName)
    {
        string sValue = "";
        int Index = reader.GetOrdinal(columnName);

        if (!reader.IsDBNull(Index))
            sValue = reader.GetString(Index);

        return sValue;
    }

    public static double GetDouble(SqlDataReader reader, string columnName)
    {
        double dValue = 0;
        int Index = reader.GetOrdinal(columnName);

        if (!reader.IsDBNull(Index))
            dValue = reader.GetDouble(Index);

        return dValue;
    }

    public static decimal GetDecimal(SqlDataReader reader, string columnName)
    {
        decimal dValue = 0;
        int Index = reader.GetOrdinal(columnName);

        if (!reader.IsDBNull(Index))
            dValue = reader.GetDecimal(Index);

        return dValue;
    }

    public static bool GetBoolean(SqlDataReader reader, string columnName)
    {
        bool dValue = false;
        int Index = reader.GetOrdinal(columnName);

        if (!reader.IsDBNull(Index))
            dValue = reader.GetBoolean(Index);

        return dValue;
    }

    public static DateTime GetDateTime(SqlDataReader reader, string columnName)
    {
        DateTime dValue = new DateTime(1753, 1, 1);
        int Index = reader.GetOrdinal(columnName);

        if (!reader.IsDBNull(Index))
            dValue = reader.GetDateTime(Index);

        return dValue;
    }

    public static Int32 GetInt32(SqlDataReader reader, string columnName)
    {
        Int32 iValue = 0;
        int Index = reader.GetOrdinal(columnName);

        if (!reader.IsDBNull(Index))
            iValue = reader.GetInt32(Index);

        return iValue;
    }

    public static Int16 GetInt16(SqlDataReader reader, string columnName)
    {
        Int16 iValue = 0;
        int Index = reader.GetOrdinal(columnName);

        if (!reader.IsDBNull(Index))
            iValue = reader.GetInt16(Index);

        return iValue;
    }

    public static Int64 GetInt64(SqlDataReader reader, string columnName)
    {
        Int64 iValue = 0;
        int Index = reader.GetOrdinal(columnName);

        if (!reader.IsDBNull(Index))
            iValue = reader.GetInt64(Index);

        return iValue;
    }

    public static Byte GetByte(SqlDataReader reader, string columnName)
    {
        Byte iValue = 0;
        int Index = reader.GetOrdinal(columnName);

        if (!reader.IsDBNull(Index))
            iValue = reader.GetByte(Index);

        return iValue;
    }

    public static byte[] GetImage(SqlDataReader reader, string columnName)
    {
        byte[] bValue = { };

        int Index = reader.GetOrdinal(columnName);

        if (!reader.IsDBNull(Index))
        {
            try
            {
                bValue = (byte[])reader[columnName];
            }
            catch (Exception)
            {
                throw;
            }
        }

        return bValue;
    }
}
