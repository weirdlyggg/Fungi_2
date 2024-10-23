PGDMP                  	    |            FungiDB    16.2    16.2 3                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            !           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            "           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            #           1262    16543    FungiDB    DATABASE     }   CREATE DATABASE "FungiDB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "FungiDB";
             	   developer    false            �            1259    16570    Articles    TABLE     �   CREATE TABLE public."Articles" (
    "Id" integer NOT NULL,
    "Title" character varying(255) NOT NULL,
    "PublishDate" timestamp with time zone
);
    DROP TABLE public."Articles";
       public         heap    postgres    false            �            1259    16569    Articles_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."Articles_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."Articles_Id_seq";
       public          postgres    false    218            $           0    0    Articles_Id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Articles_Id_seq" OWNED BY public."Articles"."Id";
          public          postgres    false    217            �            1259    16632    Articles_Id_seq1    SEQUENCE     �   ALTER TABLE public."Articles" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Articles_Id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    218            �            1259    16635    Doppelgangers    TABLE     �   CREATE TABLE public."Doppelgangers" (
    "Id" integer NOT NULL,
    "MushroomId" integer NOT NULL,
    "DoppelgangerName" character varying(100) NOT NULL
);
 #   DROP TABLE public."Doppelgangers";
       public         heap    postgres    false            �            1259    16634    Doppelgangers_Id_seq    SEQUENCE     �   ALTER TABLE public."Doppelgangers" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Doppelgangers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    230            �            1259    16591 	   Mushrooms    TABLE     �  CREATE TABLE public."Mushrooms" (
    "Id" integer NOT NULL,
    "Name" character varying(100) NOT NULL,
    "SynonymousName" character varying(100),
    "RedBook" boolean NOT NULL,
    "Eatable" character varying(15) NOT NULL,
    "HasStem" boolean NOT NULL,
    "StemSizeFrom" integer,
    "StemSizeTo" integer,
    "StemType" character varying(30),
    "SteamColor" character varying(100),
    "Description" text
);
    DROP TABLE public."Mushrooms";
       public         heap    postgres    false            �            1259    16590    Mushrooms_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."Mushrooms_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public."Mushrooms_Id_seq";
       public          postgres    false    222            %           0    0    Mushrooms_Id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public."Mushrooms_Id_seq" OWNED BY public."Mushrooms"."Id";
          public          postgres    false    221            �            1259    16633    Mushrooms_Id_seq1    SEQUENCE     �   ALTER TABLE public."Mushrooms" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Mushrooms_Id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    222            �            1259    16577 
   Paragraphs    TABLE     �   CREATE TABLE public."Paragraphs" (
    "Id" integer NOT NULL,
    "ArticleId" integer NOT NULL,
    "ParagraphText" text,
    "SerialNumber" integer NOT NULL
);
     DROP TABLE public."Paragraphs";
       public         heap    postgres    false            �            1259    16576    Paragraphs_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."Paragraphs_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."Paragraphs_Id_seq";
       public          postgres    false    220            &           0    0    Paragraphs_Id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public."Paragraphs_Id_seq" OWNED BY public."Paragraphs"."Id";
          public          postgres    false    219            �            1259    16626    Paragraphs_Id_seq1    SEQUENCE     �   ALTER TABLE public."Paragraphs" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Paragraphs_Id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    220            �            1259    16545    Roles    TABLE     f   CREATE TABLE public."Roles" (
    "Id" integer NOT NULL,
    "Name" character varying(30) NOT NULL
);
    DROP TABLE public."Roles";
       public         heap    postgres    false            �            1259    16544    Roles_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."Roles_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public."Roles_Id_seq";
       public          postgres    false    216            '           0    0    Roles_Id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public."Roles_Id_seq" OWNED BY public."Roles"."Id";
          public          postgres    false    215            �            1259    16625    Roles_Id_seq1    SEQUENCE     �   ALTER TABLE public."Roles" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Roles_Id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    216            �            1259    16614    Users    TABLE     �   CREATE TABLE public."Users" (
    "Id" integer NOT NULL,
    "Username" character varying(128) NOT NULL,
    "PasswordHash" character varying(128) NOT NULL,
    "RoleId" integer NOT NULL,
    "Email" character varying(128)
);
    DROP TABLE public."Users";
       public         heap    postgres    false            �            1259    16619    Users_Id_seq    SEQUENCE     �   ALTER TABLE public."Users" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Users_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    223                      0    16570    Articles 
   TABLE DATA           B   COPY public."Articles" ("Id", "Title", "PublishDate") FROM stdin;
    public          postgres    false    218   J9                 0    16635    Doppelgangers 
   TABLE DATA           Q   COPY public."Doppelgangers" ("Id", "MushroomId", "DoppelgangerName") FROM stdin;
    public          postgres    false    230   �9                 0    16591 	   Mushrooms 
   TABLE DATA           �   COPY public."Mushrooms" ("Id", "Name", "SynonymousName", "RedBook", "Eatable", "HasStem", "StemSizeFrom", "StemSizeTo", "StemType", "SteamColor", "Description") FROM stdin;
    public          postgres    false    222   �9                 0    16577 
   Paragraphs 
   TABLE DATA           Z   COPY public."Paragraphs" ("Id", "ArticleId", "ParagraphText", "SerialNumber") FROM stdin;
    public          postgres    false    220   �9                 0    16545    Roles 
   TABLE DATA           /   COPY public."Roles" ("Id", "Name") FROM stdin;
    public          postgres    false    216   A;                 0    16614    Users 
   TABLE DATA           V   COPY public."Users" ("Id", "Username", "PasswordHash", "RoleId", "Email") FROM stdin;
    public          postgres    false    223   ^;       (           0    0    Articles_Id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Articles_Id_seq"', 1, false);
          public          postgres    false    217            )           0    0    Articles_Id_seq1    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Articles_Id_seq1"', 4, true);
          public          postgres    false    227            *           0    0    Doppelgangers_Id_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public."Doppelgangers_Id_seq"', 2, true);
          public          postgres    false    229            +           0    0    Mushrooms_Id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."Mushrooms_Id_seq"', 1, false);
          public          postgres    false    221            ,           0    0    Mushrooms_Id_seq1    SEQUENCE SET     A   SELECT pg_catalog.setval('public."Mushrooms_Id_seq1"', 1, true);
          public          postgres    false    228            -           0    0    Paragraphs_Id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."Paragraphs_Id_seq"', 1, false);
          public          postgres    false    219            .           0    0    Paragraphs_Id_seq1    SEQUENCE SET     C   SELECT pg_catalog.setval('public."Paragraphs_Id_seq1"', 20, true);
          public          postgres    false    226            /           0    0    Roles_Id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Roles_Id_seq"', 1, false);
          public          postgres    false    215            0           0    0    Roles_Id_seq1    SEQUENCE SET     >   SELECT pg_catalog.setval('public."Roles_Id_seq1"', 1, false);
          public          postgres    false    225            1           0    0    Users_Id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Users_Id_seq"', 1, false);
          public          postgres    false    224            r           2606    16575    Articles Articles_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Articles"
    ADD CONSTRAINT "Articles_pkey" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."Articles" DROP CONSTRAINT "Articles_pkey";
       public            postgres    false    218            z           2606    16639     Doppelgangers Doppelgangers_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public."Doppelgangers"
    ADD CONSTRAINT "Doppelgangers_pkey" PRIMARY KEY ("Id");
 N   ALTER TABLE ONLY public."Doppelgangers" DROP CONSTRAINT "Doppelgangers_pkey";
       public            postgres    false    230            v           2606    16598    Mushrooms Mushrooms_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."Mushrooms"
    ADD CONSTRAINT "Mushrooms_pkey" PRIMARY KEY ("Id");
 F   ALTER TABLE ONLY public."Mushrooms" DROP CONSTRAINT "Mushrooms_pkey";
       public            postgres    false    222            t           2606    16584    Paragraphs Paragraphs_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Paragraphs"
    ADD CONSTRAINT "Paragraphs_pkey" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."Paragraphs" DROP CONSTRAINT "Paragraphs_pkey";
       public            postgres    false    220            n           2606    16552    Roles Roles_Name_key 
   CONSTRAINT     U   ALTER TABLE ONLY public."Roles"
    ADD CONSTRAINT "Roles_Name_key" UNIQUE ("Name");
 B   ALTER TABLE ONLY public."Roles" DROP CONSTRAINT "Roles_Name_key";
       public            postgres    false    216            p           2606    16550    Roles Roles_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Roles"
    ADD CONSTRAINT "Roles_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Roles" DROP CONSTRAINT "Roles_pkey";
       public            postgres    false    216            x           2606    16618    Users Users_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Users" DROP CONSTRAINT "Users_pkey";
       public            postgres    false    223            {           1259    16702 !   fki_Doppelgangers_MushroomId_fkey    INDEX     g   CREATE INDEX "fki_Doppelgangers_MushroomId_fkey" ON public."Doppelgangers" USING btree ("MushroomId");
 7   DROP INDEX public."fki_Doppelgangers_MushroomId_fkey";
       public            postgres    false    230            ~           2606    16703 +   Doppelgangers Doppelgangers_MushroomId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Doppelgangers"
    ADD CONSTRAINT "Doppelgangers_MushroomId_fkey" FOREIGN KEY ("MushroomId") REFERENCES public."Mushrooms"("Id") ON DELETE CASCADE;
 Y   ALTER TABLE ONLY public."Doppelgangers" DROP CONSTRAINT "Doppelgangers_MushroomId_fkey";
       public          postgres    false    4726    230    222            |           2606    16585 $   Paragraphs Paragraphs_ArticleId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Paragraphs"
    ADD CONSTRAINT "Paragraphs_ArticleId_fkey" FOREIGN KEY ("ArticleId") REFERENCES public."Articles"("Id") ON DELETE CASCADE;
 R   ALTER TABLE ONLY public."Paragraphs" DROP CONSTRAINT "Paragraphs_ArticleId_fkey";
       public          postgres    false    220    218    4722            }           2606    16627    Users Users_RoleId_fkey    FK CONSTRAINT        ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Roles"("Id");
 E   ALTER TABLE ONLY public."Users" DROP CONSTRAINT "Users_RoleId_fkey";
       public          postgres    false    216    4720    223               a   x�3�I-.Qp,*�L�I�420��50�50S04�24�21�60�2ἰ��/컰�b�����D��@��@��������L�������!F��� M\�            x������ � �            x������ � �         <  x�UP�N�@��b? 89�@�hh��(��cty �D ����2q0�ql~a���;�A�������5FjЏ{��nS�����-`�	 (_���A�@�] W7�$�S�6{*T��+�ᚗ2D� �y�5W�2�Q+�E��0.�&cW�,S;�:�/����\��p-ώ�����W$��=��}��2?�1�2�|)/2E�V�)#g�9�����%]៷c�q���5�h��&���go�E{���4�����u�E�����Qt|�[��O;�o�gMR�m� �I�A���9����O=�����<            x������ � �            x������ � �     