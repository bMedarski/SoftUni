# -*- coding: utf-8 -*-
# Generated by Django 1.11 on 2018-09-26 10:10
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('books', '0007_auto_20180926_1307'),
    ]

    operations = [
        migrations.RenameField(
            model_name='author',
            old_name='email',
            new_name='website',
        ),
        migrations.AlterField(
            model_name='author',
            name='genres',
            field=models.CharField(choices=[('Science fiction', 'Science fiction'), ('Satire', 'Satire'), ('Drama', 'Drama'), ('Action and Adventure', 'Action and Adventure'), ('Romance', 'Romance'), ('Mystery', 'Mystery'), ('Fantasy', 'Mystery'), ('Biographies', 'Biographies'), ('Travel', 'Travel'), ('Religion, Spirituality & New Age', 'Religion, Spirituality & New Age')], max_length=3, null=True),
        ),
    ]