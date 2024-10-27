PGDMP  (                	    |            FungiDB    16.2    16.2                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16543    FungiDB    DATABASE     }   CREATE DATABASE "FungiDB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "FungiDB";
             	   developer    false            �            1259    16725    Articles    TABLE     �   CREATE TABLE public."Articles" (
    "Id" uuid NOT NULL,
    "Title" character varying(255) NOT NULL,
    "PublishDate" timestamp with time zone
);
    DROP TABLE public."Articles";
       public         heap    postgres    false            �            1259    16750    Doppelgangers    TABLE     �   CREATE TABLE public."Doppelgangers" (
    "Id" uuid NOT NULL,
    "MushroomId" uuid NOT NULL,
    "DoppelgangerName" character varying(100) NOT NULL
);
 #   DROP TABLE public."Doppelgangers";
       public         heap    postgres    false            �            1259    16743 	   Mushrooms    TABLE     �  CREATE TABLE public."Mushrooms" (
    "Id" uuid NOT NULL,
    "Name" character varying(100) NOT NULL,
    "SynonymousName" character varying(100),
    "RedBook" boolean NOT NULL,
    "Eatable" character varying(15) NOT NULL,
    "HasStem" boolean NOT NULL,
    "StemSizeFrom" integer,
    "StemSizeTo" integer,
    "StemType" character varying(30),
    "StemColor" character varying(100),
    "Description" text
);
    DROP TABLE public."Mushrooms";
       public         heap    postgres    false            �            1259    16730 
   Paragraphs    TABLE     �   CREATE TABLE public."Paragraphs" (
    "Id" uuid NOT NULL,
    "ArticleId" uuid NOT NULL,
    "ParagraphText" text,
    "SerialNumber" integer NOT NULL
);
     DROP TABLE public."Paragraphs";
       public         heap    postgres    false            �            1259    16708    Roles    TABLE     c   CREATE TABLE public."Roles" (
    "Id" uuid NOT NULL,
    "Name" character varying(30) NOT NULL
);
    DROP TABLE public."Roles";
       public         heap    postgres    false            �            1259    16713    Users    TABLE     �   CREATE TABLE public."Users" (
    "Id" uuid NOT NULL,
    "Username" character varying(128) NOT NULL,
    "Email" character varying(128),
    "PasswordHash" character varying(128) NOT NULL,
    "RoleId" uuid NOT NULL
);
    DROP TABLE public."Users";
       public         heap    postgres    false                      0    16725    Articles 
   TABLE DATA           B   COPY public."Articles" ("Id", "Title", "PublishDate") FROM stdin;
    public          postgres    false    217   !       	          0    16750    Doppelgangers 
   TABLE DATA           Q   COPY public."Doppelgangers" ("Id", "MushroomId", "DoppelgangerName") FROM stdin;
    public          postgres    false    220   +!                 0    16743 	   Mushrooms 
   TABLE DATA           �   COPY public."Mushrooms" ("Id", "Name", "SynonymousName", "RedBook", "Eatable", "HasStem", "StemSizeFrom", "StemSizeTo", "StemType", "StemColor", "Description") FROM stdin;
    public          postgres    false    219   H!                 0    16730 
   Paragraphs 
   TABLE DATA           Z   COPY public."Paragraphs" ("Id", "ArticleId", "ParagraphText", "SerialNumber") FROM stdin;
    public          postgres    false    218   e!                 0    16708    Roles 
   TABLE DATA           /   COPY public."Roles" ("Id", "Name") FROM stdin;
    public          postgres    false    215   �!                 0    16713    Users 
   TABLE DATA           V   COPY public."Users" ("Id", "Username", "Email", "PasswordHash", "RoleId") FROM stdin;
    public          postgres    false    216   �!       i           2606    16729    Articles Articles_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Articles"
    ADD CONSTRAINT "Articles_pkey" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."Articles" DROP CONSTRAINT "Articles_pkey";
       public            postgres    false    217            p           2606    16754     Doppelgangers Doppelgangers_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public."Doppelgangers"
    ADD CONSTRAINT "Doppelgangers_pkey" PRIMARY KEY ("Id");
 N   ALTER TABLE ONLY public."Doppelgangers" DROP CONSTRAINT "Doppelgangers_pkey";
       public            postgres    false    220            n           2606    16749    Mushrooms Mushrooms_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."Mushrooms"
    ADD CONSTRAINT "Mushrooms_pkey" PRIMARY KEY ("Id");
 F   ALTER TABLE ONLY public."Mushrooms" DROP CONSTRAINT "Mushrooms_pkey";
       public            postgres    false    219            k           2606    16736    Paragraphs Paragraphs_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Paragraphs"
    ADD CONSTRAINT "Paragraphs_pkey" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."Paragraphs" DROP CONSTRAINT "Paragraphs_pkey";
       public            postgres    false    218            d           2606    16712    Roles Roles_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Roles"
    ADD CONSTRAINT "Roles_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Roles" DROP CONSTRAINT "Roles_pkey";
       public            postgres    false    215            f           2606    16717    Users Users_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Users" DROP CONSTRAINT "Users_pkey";
       public            postgres    false    216            q           1259    16760 !   fki_Doppelgangers_MushroomId_fkey    INDEX     g   CREATE INDEX "fki_Doppelgangers_MushroomId_fkey" ON public."Doppelgangers" USING btree ("MushroomId");
 7   DROP INDEX public."fki_Doppelgangers_MushroomId_fkey";
       public            postgres    false    220            l           1259    16742    fki_Paragraphs_ArticleId_fkey    INDEX     _   CREATE INDEX "fki_Paragraphs_ArticleId_fkey" ON public."Paragraphs" USING btree ("ArticleId");
 3   DROP INDEX public."fki_Paragraphs_ArticleId_fkey";
       public            postgres    false    218            g           1259    16723    fki_Users_RoleId_fkey    INDEX     O   CREATE INDEX "fki_Users_RoleId_fkey" ON public."Users" USING btree ("RoleId");
 +   DROP INDEX public."fki_Users_RoleId_fkey";
       public            postgres    false    216            t           2606    16755 +   Doppelgangers Doppelgangers_MushroomId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Doppelgangers"
    ADD CONSTRAINT "Doppelgangers_MushroomId_fkey" FOREIGN KEY ("MushroomId") REFERENCES public."Mushrooms"("Id") ON DELETE CASCADE;
 Y   ALTER TABLE ONLY public."Doppelgangers" DROP CONSTRAINT "Doppelgangers_MushroomId_fkey";
       public          postgres    false    220    219    4718            s           2606    16737 $   Paragraphs Paragraphs_ArticleId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Paragraphs"
    ADD CONSTRAINT "Paragraphs_ArticleId_fkey" FOREIGN KEY ("ArticleId") REFERENCES public."Articles"("Id") ON DELETE CASCADE;
 R   ALTER TABLE ONLY public."Paragraphs" DROP CONSTRAINT "Paragraphs_ArticleId_fkey";
       public          postgres    false    218    217    4713            r           2606    16718    Users Users_RoleId_fkey    FK CONSTRAINT        ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Roles"("Id");
 E   ALTER TABLE ONLY public."Users" DROP CONSTRAINT "Users_RoleId_fkey";
       public          postgres    false    215    4708    216                  x������ � �      	      x������ � �            x������ � �            x������ � �            x������ � �            x������ � �     