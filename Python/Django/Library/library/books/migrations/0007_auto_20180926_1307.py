# -*- coding: utf-8 -*-
# Generated by Django 1.11 on 2018-09-26 10:07
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('books', '0006_auto_20180926_1214'),
    ]

    operations = [
        migrations.AddField(
            model_name='author',
            name='country',
            field=models.CharField(max_length=30, null=True),
        ),
        migrations.AddField(
            model_name='author',
            name='email',
            field=models.EmailField(max_length=254, null=True),
        ),
        migrations.AddField(
            model_name='author',
            name='genres',
            field=models.CharField(choices=[('Science fiction', 'Science fiction'), ('Satire', 'Satire'), ('Drama', 'Drama'), ('Action and Adventure', 'Action and Adventure'), ('Romance', 'Romance'), ('Mystery', 'Mystery'), ('Fantasy', 'Mystery'), ('Biographies', 'Biographies'), ('Travel', 'Travel'), ('Religion, Spirituality & New Age', 'Religion, Spirituality & New Age')], max_length=1, null=True),
        ),
        migrations.AddField(
            model_name='author',
            name='place_of_birth',
            field=models.CharField(max_length=50, null=True),
        ),
    ]
