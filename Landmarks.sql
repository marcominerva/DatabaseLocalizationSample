CREATE TABLE [dbo].[Landmarks](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](255) NULL,
 CONSTRAINT [PK_Landmarks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LandmarkTranslations]    Script Date: 08/09/2023 11:38:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LandmarkTranslations](
	[Id] [uniqueidentifier] NOT NULL,
	[LandmarkId] [uniqueidentifier] NOT NULL,
	[Language] [char](2) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_LandmarkTranslations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Landmarks] ([Id], [Name], [Description], [ImageUrl]) VALUES (N'8a1676d3-1201-41c2-afbb-659fcabd1379', N'Chiesa e convento dei Domenicani', N'Complesso architettonico ed artistico, fondato nel 1459 in seguito alla predicazione del beato Cristoforo da Milano e costruito a più riprese a partire dal 1460. Conserva una eccezionale sequenza di polittici tardomedievali, con prevalenza di opere di Ludovico Brea, Giovanni Canavesio ed altri dipinti fino al XVIII secolo, oltre alla "Adorazione dei Magi" del Parmigianino del XVI secolo. Il convento assolve un ruolo devozionale e culturale di grande importanza.', N'https://projecttabya.blob.core.windows.net/images/taggia/chiesa-domenicani/20230328_181952.jpg')
GO
INSERT [dbo].[Landmarks] ([Id], [Name], [Description], [ImageUrl]) VALUES (N'8015aedb-0e05-4c23-bcf2-a0fda16522dc', N'Chiesa di Nostra Signora del Canneto', N'Complesso edificio sacro, sviluppato su due balze (esisteva infatti anche la chiesa inferiore di Sant''Anna). Collocata lungo la strada per Badalucco, è frutto di varie fasi costruttive, a partire dall''alto Medioevo, con successivo intervento principale del XII secolo. Dopo il riferimento all''abbazzia benedittina di San Dalmazzo di Pedona (presso Cuneo), il titolo è passato ai Domenicani. La chiesa è stata decorata da un ciclo murale dipinto nel 1547 ad opera di Giovanni e Luca Cambiaso con Francesco Brea.', N'https://projecttabya.blob.core.windows.net/images/taggia/chiesa-canneto/20230327_190055.jpg')
GO
INSERT [dbo].[Landmarks] ([Id], [Name], [Description], [ImageUrl]) VALUES (N'1ee0ab45-5b7a-4a6f-a618-fd983db4d54c', N'Bastione grosso o dei Berruti', N'Il grande bastione protegge la porta dell''Orso e tutto il quartiere di espansione tardomedievale che fa capo a Via Lercari. Siccome il pericolo maggiore era quello che veniva dal mare, appare evidente che qui si concentrino gli sforzi difensivi. Si tratta dunque di uno dei primi settori messi a difesa, con le opere del 1540.', N'https://projecttabya.blob.core.windows.net/images/taggia/bastione-berruti/20230327_182755.jpg')
GO
INSERT [dbo].[LandmarkTranslations] ([Id], [LandmarkId], [Language], [Name], [Description]) VALUES (N'283acf9e-5d0c-43d9-b636-87970556b156', N'8a1676d3-1201-41c2-afbb-659fcabd1379', N'en', N'Church and convent of Dominicans', N'Architectural and artistic complex, founded in 1459 following the preaching of blessed Christopher from Milan and built on several occasions since 1460. It preserves an exceptional sequence of late medieval polyps, with prevalent works by Ludovico Brea, Giovanni Canavesio and other paintings up to XVIII century, in addition to the "Adoration of the Magi" of the Parmigianino of the XVI century. The convent has a devotional and cultural role of great importance.')
GO
INSERT [dbo].[LandmarkTranslations] ([Id], [LandmarkId], [Language], [Name], [Description]) VALUES (N'69339488-5799-4664-89cf-8e697b600ef2', N'8015aedb-0e05-4c23-bcf2-a0fda16522dc', N'en', N'Church of Nostra Signora del Canneto', N'Complex sacred building, built on two bales (in fact there was also the lower church of Sant''Anna). Placed along the road to Badalucco, it is the result of several constructive phases, beginning with the Middle Ages, with the subsequent main intervention in the XII century. After referring to the Benedictine abbey of San Dalmazzo di Pedona (near Cuneo), the title went to the Dominicans. The church was decorated with a mural cycle painted in 1547 by Giovanni and Luca Cambiaso with Francesco Brea.')
GO
INSERT [dbo].[LandmarkTranslations] ([Id], [LandmarkId], [Language], [Name], [Description]) VALUES (N'40b58f12-9c18-47e6-90af-a90bfcf9cccc', N'1ee0ab45-5b7a-4a6f-a618-fd983db4d54c', N'en', N'Big or Berruti''s Bastion', N'The big bastion protects the Bear''s door and the entire late medieval expansion zone that leads to Via Lercari. Since the greatest danger was that coming from the sea, it is evident that defensive efforts are concentrated here. It is therefore one of the first sectors to be defended, with the works of 1540.')
GO
INSERT [dbo].[LandmarkTranslations] ([Id], [LandmarkId], [Language], [Name], [Description]) VALUES (N'e4a30b7b-3394-4feb-be5e-baf2319bf131', N'8a1676d3-1201-41c2-afbb-659fcabd1379', N'de', N'Dominikanerkloster und Kirche', N'Architektonischer und künstlicher Komplex, der im Jahr 1459 nach dem Predigen von Cristoforo da Milano gegrundet wurde. Das Kloster verwahrt zahlreiche Flügelaltare aus dem Spätmittelalter, meistens Werke von Ludovico Brea und Giovanni Canavesio, dazu soll man andere Kunstwerke aus späteren Jahrhunderten erwähnen, wie zum Beispiel die Anbetung der Könige aus dem Morgenland von Parmigianino. Das Kloster gilt noch heute als ein wichter Andachtsort in der Gegend.')
GO
INSERT [dbo].[LandmarkTranslations] ([Id], [LandmarkId], [Language], [Name], [Description]) VALUES (N'02cec0ae-9a2d-493e-a29c-be798408119c', N'8015aedb-0e05-4c23-bcf2-a0fda16522dc', N'de', N'Kirche von Nostra Signora del Canneto', N'Diese Kirche befindet sich den Weg nach Badalucco entlang und seit dem frühen Mittelalter wurde mehrmals wieder aufgebaut. Zu Anfang war die Kirche mit dem Benedektinerkloster von Pedona (heutig San Dalmazzo in westsüdlichem Piemont) verbunden, aber danach gehörte den Dominikanern. Die Fresken der Kirchen sind zu Giovanni und Luca Cambiaso und Francesco Brea zegeschrieben.')
GO
INSERT [dbo].[LandmarkTranslations] ([Id], [LandmarkId], [Language], [Name], [Description]) VALUES (N'bdfd6770-4207-4e08-ad00-ec0b92b5871c', N'1ee0ab45-5b7a-4a6f-a618-fd983db4d54c', N'de', N'Größe Bastion oder von Berruti', N'Die größe Bastion verteidigte das Tor des Bären und den ganzen spätmittelalterlichen Viertel von Via Lercari. Die Angriffe kamen meistens vom Meer und deshalb ist selbstverständlich dass die Verteidigungskraft der Stadt hier konzentriert wurde, besonders in Richtung nach Meer und in der Nähe vom Dominikanerkloster.')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_LandmarkTranslations]    Script Date: 08/09/2023 11:38:07 ******/
ALTER TABLE [dbo].[LandmarkTranslations] ADD  CONSTRAINT [IX_LandmarkTranslations] UNIQUE NONCLUSTERED 
(
	[LandmarkId] ASC,
	[Language] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Landmarks] ADD  CONSTRAINT [DF_Landmarks_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[LandmarkTranslations] ADD  CONSTRAINT [DF_LandmarkTranslations_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[LandmarkTranslations]  WITH CHECK ADD  CONSTRAINT [FK_LandmarkTranslations_Landmarks] FOREIGN KEY([LandmarkId])
REFERENCES [dbo].[Landmarks] ([Id])
GO
ALTER TABLE [dbo].[LandmarkTranslations] CHECK CONSTRAINT [FK_LandmarkTranslations_Landmarks]
GO
