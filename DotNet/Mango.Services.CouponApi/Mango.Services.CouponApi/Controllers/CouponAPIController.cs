using AutoMapper;
using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Models;
using Mango.Services.CouponApi.Models.Dto;
using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Models;
using Mango.Services.CouponApi.Models.Dto;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class CouponAPIController : ControllerBase

    {

        private readonly AppDbContext _db;

        private ResponseDto _response;

        private IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper)

        {

            _db = db;

            _mapper = mapper;

            _response = new ResponseDto();

        }

        [HttpGet]

        public ResponseDto Get()

        {

            try

            {

                IEnumerable<Coupon> objList = _db.Coupons.ToList();

                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);

            }

            catch (Exception ex)

            {

                _response.IsSuccess = false;

                _response.Message = ex.Message;

            }

            return _response;

        }

        [HttpGet]

        [Route("{id:int}")]

        public ResponseDto Get(int id)

        {

            try

            {

                Coupon obj = _db.Coupons.First(u => u.CouponId == id);

                _response.Result = _mapper.Map<CouponDto>(obj);

            }

            catch (Exception ex)

            {

                _response.IsSuccess = false;

                _response.Message = ex.Message;

            }

            return _response;

        }
        [HttpGet]

        [Route("GetByCode/{code}")]

        public ResponseDto GetByCode(string code)

        {

            try

            {

                Coupon obj = _db.Coupons.FirstOrDefault(u => u.CounponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(obj);

            }

            catch (Exception ex)

            {

                _response.IsSuccess = false;

                _response.Message = ex.Message;

            }

            return _response;

        }

    }

}

//Let’s add one more end point to get coupon details by coupon code.

