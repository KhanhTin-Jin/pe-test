# ===== Build stage =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj trước để cache restore
COPY PRN232_PE_SU25_NguyenKhanhTin/*.csproj PRN232_PE_SU25_NguyenKhanhTin/
RUN dotnet restore PRN232_PE_SU25_NguyenKhanhTin/PRN232_PE_SU25_NguyenKhanhTin.csproj

# copy toàn bộ source và publish
COPY . .
RUN dotnet publish PRN232_PE_SU25_NguyenKhanhTin/PRN232_PE_SU25_NguyenKhanhTin.csproj -c Release -o /app/out

# ===== Runtime stage =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Render cấp biến $PORT → bind đúng địa chỉ
CMD ["sh","-c","dotnet PRN232_PE_SU25_NguyenKhanhTin.dll --urls=http://0.0.0.0:$PORT"]
