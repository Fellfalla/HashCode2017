import os, zipfile

endings = [".cs", ".csproj", ".sln"]

filesToZip = []
zipName = 'Droniator'
for fname in os.listdir('.'):
    basename, ext = os.path.splitext(fname)
    if ext.lower().endswith('zip'): continue
    if not ext.lower().endswith('.cs'): continue
    filesToZip.append(fname)
    print fname

f = zipfile.ZipFile('%s.zip' % zipName, 'w')

for file in filesToZip:
    f.write(file)

f.close()
