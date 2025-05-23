﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.CourseDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin,Teacher,Student")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService _courseService, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("GetCoursesWithEverythingById/{id}")]
        public IActionResult GetCoursesWithEverythingById(int id)
        {
            var values = _courseService.AGetCoursesWithCategory(x => x.CourseCategoryId == id);
            var categories = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(categories);
        }
        [AllowAnonymous]
        [HttpGet("GetCoursesWithCategoryAndWithTeacher")]
        public IActionResult GetCoursesWithCategoryAndWithTeacher()
        {
            var values = _courseService.AGetCoursesWithCategoryAndWithTeacher();
            var categories = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _courseService.AGetById(id);
            return Ok(value);
        }
        [AllowAnonymous]
        [HttpGet("GetActiveCourse")]
        public IActionResult GetActiveCourse()
        {
            var values = _courseService.AGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseService.ADelete(id);
            return Ok("Kurs Silme Basarili");
        }
        [HttpPost]
        public IActionResult Create(CreateCourseDto createCourseDto)
        {
            var value = _mapper.Map<Course>(createCourseDto);
            _courseService.ACreate(value);
            return Ok("Kurs Ekleme Basarili");
        }
        [HttpPut]
        public IActionResult Update(UpdateCourseDto updateCourseDto)
        {
            var value = _mapper.Map<Course>(updateCourseDto);
            _courseService.AUpdate(value);
            return Ok("Kurs Guncelleme Basarili");
        }
        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _courseService.AShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor.");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _courseService.ADontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor.");
        }
        [AllowAnonymous]
        [HttpGet("GetCourseWithTeacherId/{id}")]
        public IActionResult GetCourseWithTeacherId(int id)
        {
            var values = _courseService.AGetCoursesWithCategoryByTeacher(id);
            var mappedavlues = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(mappedavlues);
        }
        [AllowAnonymous]
        [HttpGet("GetCourseCount")]
        public IActionResult GetCourseCount()
        {
            var value = _courseService.ACount();
            return Ok(value);
        }
    }
}
