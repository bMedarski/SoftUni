from django.db import models

class Author(models.Model):
    first_name = models.CharField(max_length=20,null=True)
    second_name = models.CharField(max_length=20,null=True)
    birthday =  models.DateField(null=True)
    created = models.DateField(auto_now_add=True)
    picture = models.CharField(max_length=100,null=True)

    def __str__(self):
        return f"{self.first_name} {self.second_name}"

class Book(models.Model):
    title = models.CharField(max_length=20,null=True)
    description = models.TextField(null=True)
    author = models.ForeignKey(Author,on_delete=models.CASCADE,null=True)
    created = models.DateField(auto_now_add=True)
    cover_image = models.CharField(max_length=100,null=True)

