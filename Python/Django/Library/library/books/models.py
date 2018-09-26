from django.db import models


# GENRE_TYPES = (
#             ('1','Science fiction'),
#             ('2','Satire'),
#             ('3','Drama'),
#             ('4','Action and Adventure'),
#             ('5','Romance'),
#             ('6','Mystery'),
#             ('7','Mystery'),
#             ('8','Biographies'),
#             ('9','Travel'),
#             ('10, Spirituality & New Age'),
#             )

class Genre(models.Model):
    name = models.CharField(max_length=50)

    def __str__(self):
        return f"{self.name}"

class Author(models.Model):
    first_name = models.CharField(max_length=20,null=True)
    second_name = models.CharField(max_length=20,null=True)
    birthday =  models.DateField(null=True)
    created = models.DateField(auto_now_add=True)
    picture = models.CharField(max_length=100,null=True)
    website = models.CharField(max_length=50,null=True)
    country = models.CharField(max_length=30,null=True)
    place_of_birth =  models.CharField(max_length=50,null=True)
    # genres = models.CharField(choices=GENRE_TYPES,max_length=20,null=True)
    # genres = models.ForeignKey(Genre,on_delete=models.CASCADE,null=True)
    genres = models.ManyToManyField(Genre,null=True)

    def __str__(self):
        return f"{self.first_name} {self.second_name}"

class Book(models.Model):
    title = models.CharField(max_length=20,null=True)
    description = models.TextField(null=True)
    author = models.ForeignKey(Author,on_delete=models.CASCADE,null=True)
    published_year = models.PositiveIntegerField(max_length=4,null=True)
    cover_image = models.CharField(max_length=100,null=True)

    def __str__(self):
        return f"{self.title}"